using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace STSdb4.Storage
{
    public class Space
    {
        private const int MIN_THRESHOLD_REALLOCATION = 64 * 1024 * 1024;

        private int activeChunkIndex = -1;
        private List<Ptr> free = new List<Ptr>(); //free chunks are always: ordered by position, not overlapped & not contiguous

        public long FreeBytes { get; private set; }
        public int MinThresholdReallocation { get; set; }

        public Space(int minThresholdReallocation)
        {
            if (minThresholdReallocation < 0)
                throw new ArgumentException("minThresholdReallocation");

            MinThresholdReallocation = minThresholdReallocation;
        }

        public Space()
            : this(MIN_THRESHOLD_REALLOCATION)
        {
        }

        public void Add(Ptr freeChunk)
        {
            if (free.Count == 0)
                free.Add(freeChunk);
            else
            {
                var last = free[free.Count - 1];
                if (freeChunk.Position > last.PositionPlusSize)
                    free.Add(freeChunk);
                else if (freeChunk.Position == last.PositionPlusSize)
                {
                    last.Size += freeChunk.Size;
                    free[free.Count - 1] = last;
                }
                else
                    throw new ArgumentException("Invalid ptr order.");
            }

            FreeBytes += freeChunk.Size;
        }

        private int FindMaxFreeChunkIndex(int index, int count)
        {
            int idx = -1;
            long size = 0;

            for (int i = index; i < count; i++)
            {
                var ptr = free[i];
                if (ptr.Size > size)
                {
                    idx = i;
                    size = ptr.Size;
                }
            }

            return idx;
        }

        /// <summary>
        /// If the active chunk is the last one and there is at least 64MB free space in all previous chunks, then try to set another active chunk.
        /// </summary>
        private bool TryToSetPrevActiveChunk(long size)
        {
            if (free.Count <= 1 || activeChunkIndex < free.Count - 1)
                return false;

            var last = free[free.Count - 1];

            if (FreeBytes < MinThresholdReallocation)
            {
                //if ((PERCENT / 100.0) * (FreeBytes - last.Size) < last.Position)
                    return false;
            }

            int idx = FindMaxFreeChunkIndex(0, free.Count - 1);
            if (idx < 0 || free[idx].Size < size)
                return false;

            activeChunkIndex = idx;

            return true;
        }

        public Ptr Alloc(long size)
        {
            if (activeChunkIndex < 0)
            {
                activeChunkIndex = FindMaxFreeChunkIndex(0, free.Count);
                if (activeChunkIndex < 0)
                    throw new Exception("Not enough free space.");
                else
                    TryToSetPrevActiveChunk(size);
            }

            if (free[activeChunkIndex].Size < size)
            {
                activeChunkIndex = FindMaxFreeChunkIndex(0, free.Count);
                if (activeChunkIndex < 0 || free[activeChunkIndex].Size < size)
                    throw new Exception("Not enough free space.");
                else
                    TryToSetPrevActiveChunk(size);
            }

            Ptr ptr = free[activeChunkIndex];

            long pos = ptr.Position;
            ptr.Position += size;
            ptr.Size -= size;

            if (ptr.Size > 0)
                free[activeChunkIndex] = ptr;
            else
            {
                free.RemoveAt(activeChunkIndex);
                activeChunkIndex = -1; //search for active chunk at next alloc
            }

            FreeBytes -= size;

            return new Ptr(pos, size);
        }

        public void Free(Ptr ptr)
        {
            int idx = free.BinarySearch(ptr);
            if (idx >= 0)
                throw new ArgumentException("Space already freed.");

            idx = ~idx;
            if ((idx < free.Count && ptr.PositionPlusSize > free[idx].Position) || (idx > 0 && ptr.Position < free[idx - 1].PositionPlusSize))
                throw new ArgumentException("Can't free overlapped space.");

            bool merged = false;

            if (idx < free.Count) //try merge with right chunk
            {
                var p = free[idx];
                if (ptr.PositionPlusSize == p.Position)
                {
                    p.Position -= ptr.Size;
                    p.Size += ptr.Size;
                    free[idx] = p;
                    merged = true;
                }
            }

            if (idx > 0) //try merge with left chunk
            {
                var p = free[idx - 1];
                if (ptr.Position == p.PositionPlusSize)
                {
                    if (merged)
                    {
                        p.Size += free[idx].Size;
                        free[idx - 1] = p;
                        free.RemoveAt(idx);
                        if (activeChunkIndex >= idx)
                            activeChunkIndex--;
                    }
                    else
                    {
                        p.Size += ptr.Size;
                        free[idx - 1] = p;
                        merged = true;
                    }
                }
            }

            if (!merged)
                free.Insert(idx, ptr);

            FreeBytes += ptr.Size;
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(free.Count);
            for (int i = 0; i < free.Count; i++)
                free[i].Serialize(writer);
        }

        public void Deserealize(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            free.Clear();
            FreeBytes = 0;

            for (int i = 0; i < count; i++)
            {
                var ptr = Ptr.Deserialize(reader);
                free.Add(ptr);
                FreeBytes += ptr.Size;
            }

            activeChunkIndex = -1;
        }
    }
}