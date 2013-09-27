using STSdb4.General.IO;
using STSdb4.WaterfallTree;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using STSdb4.General.Collections;
using STSdb4.General.Extensions;
using System.IO.Compression;
using STSdb4.General.Compression;

namespace STSdb4.Storage
{
    public class Heap : IHeap
    {
        private readonly object SyncRoot = new object();
        private AtomicHeader header;
        private readonly Space space;

        //handle -> pointer
        private readonly Dictionary<long, Pointer> used; 
        private readonly Dictionary<long, Pointer> reserved;

        private long currentVersion;
        private long maxHandle;

        public bool UseCompression = false;

        public Stream System { get; private set; }
        public Stream Data { get; private set; }

        public Heap(Stream system, Stream data, long initialFreeSize, bool useCompression)
        {
            system.Seek(0, SeekOrigin.Begin); //support Seek?
            data.Seek(0, SeekOrigin.Begin); //support Seek?

            System = system;
            Data = data;

            header = AtomicHeader.Deserialize(System);
            space = new Space();
            used = new Dictionary<long, Pointer>();
            reserved = new Dictionary<long, Pointer>();

            if (header.LastFlush == Ptr.NULL)
                space.Add(new Ptr(0, initialFreeSize));
            else
            {
                system.Seek(header.LastFlush.Position, SeekOrigin.Begin);
                Deserialize(new BinaryReader(system));
            }

            UseCompression = useCompression;

            currentVersion++;
        }

        private void FreeOldVersions()
        {
            List<long> forRemove = new List<long>();

            foreach (var kv in reserved)
            {
                var handle = kv.Key;
                var pointer = kv.Value;
                if (pointer.RefCount > 0)
                    continue;

                space.Free(pointer.Ptr);
                forRemove.Add(handle);
            }

            foreach (var handle in forRemove)
                reserved.Remove(handle);
        }

        private void InternalWrite(long position, bool useCompression, int originalCount, byte[] buffer, int index, int count)
        {
            BinaryWriter writer = new BinaryWriter(Data);
            Data.Seek(position, SeekOrigin.Begin);
            
            writer.Write(useCompression);

            if (useCompression)
                writer.Write(originalCount);

            writer.Write(buffer, index, count);
        }

        private byte[] InternalRead(long position, long size)
        {
            BinaryReader reader = new BinaryReader(Data);
            Data.Seek(position, SeekOrigin.Begin);

            bool useCompression = reader.ReadBoolean();
            byte[] buffer;

            if (!useCompression)
                buffer = reader.ReadBytes((int)size - 1);   
            else
            {
                byte[] raw = new byte[reader.ReadInt32()];
                buffer = reader.ReadBytes((int)size - sizeof(int) - 1);

                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    using (DeflateStream decompress = new DeflateStream(stream, CompressionMode.Decompress))
                        decompress.Read(raw, 0, raw.Length);
                }

                buffer = raw;
            }

            return buffer;
        }

        private void Serialize(BinaryWriter writer)
        {
            writer.Write(maxHandle);
            writer.Write(currentVersion);

            //write free
            space.Serialize(writer);

            //write used
            writer.Write(used.Count);
            foreach (var kv in used)
            {
                writer.Write(kv.Key);
                kv.Value.Serialize(writer);
            }

            //write reserved
            writer.Write(reserved.Count);
            foreach (var kv in reserved)
            {
                writer.Write(kv.Key);
                kv.Value.Serialize(writer);
            }
        }

        private void Deserialize(BinaryReader reader)
        {
            maxHandle = reader.ReadInt64();
            currentVersion = reader.ReadInt64();

            //read free
            space.Deserealize(reader);

            //read used
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                var handle = reader.ReadInt64();
                var pointer = Pointer.Deserialize(reader);
                used.Add(handle, pointer);
            }

            //read reserved
            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                var handle = reader.ReadInt64();
                var pointer = Pointer.Deserialize(reader);
                reserved.Add(handle, pointer);
            }
        }

        public byte[] Tag
        {
            get { return header.Tag; }
            set { header.Tag = value;  }
        }

        public long ObtainHandle()
        {
            lock (SyncRoot)
                return maxHandle++;
        }

        public void Release(long handle)
        {
            lock (SyncRoot)
            {
                Pointer pointer;
                if (!used.TryGetValue(handle, out pointer))
                    return; //throw new ArgumentException("handle");

                if (pointer.Version == currentVersion)
                    space.Free(pointer.Ptr);
                else
                {
                    pointer.IsReserved = true;
                    reserved.Add(handle, pointer);
                }

                used.Remove(handle);
            }
        }

        public bool Exists(long handle)
        {
            lock (SyncRoot)
                return used.ContainsKey(handle);
        }

        /// <summary>
        /// Before writting, handle must be obtained.
        /// </summary>
        public void Write(long handle, byte[] buffer, int index, int count)
        {
            int originalCount = count;

            if (UseCompression)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (DeflateStream compress = new DeflateStream(stream, CompressionMode.Compress, true))
                        compress.Write(buffer, index, count);

                    buffer = stream.GetBuffer();
                    index = 0;
                    count = (int)stream.Length;
                }
            }

            lock (SyncRoot)
            {
                Pointer pointer;
                if (used.TryGetValue(handle, out pointer))
                {
                    if (pointer.Version == currentVersion)
                        space.Free(pointer.Ptr);
                    else
                    {
                        pointer.IsReserved = true;
                        reserved.Add(handle, pointer);
                    }
                }

                long size = UseCompression ? 1 + sizeof(int) + count : 1 + count;
                Ptr ptr = space.Alloc(size);
                used[handle] = pointer = new Pointer(currentVersion, ptr);

                InternalWrite(ptr.Position, UseCompression, originalCount, buffer, index, count);
            }
        }

        public byte[] Read(long handle)
        {
            lock (SyncRoot)
            {
                Pointer pointer;
                if (!used.TryGetValue(handle, out pointer))
                    throw new ArgumentException("No such handle exists.");

                Ptr ptr = pointer.Ptr;
                Debug.Assert(ptr != Ptr.NULL);

                return InternalRead(ptr.Position, ptr.Size);
            }
        }

        public void Commit()
        {
            lock (SyncRoot)
            {
                FreeOldVersions();

                using (MemoryStream ms = new MemoryStream())
                {
                    Serialize(new BinaryWriter(ms));

                    //if there is not enough space between the header and the last flush location, write after the last flush, else write immediately after the header.
                    bool writeNext = header.LastFlush != Ptr.NULL && ms.Length > header.LastFlush.Position - AtomicHeader.SIZE + 1;

                    long pos = writeNext ? header.LastFlush.PositionPlusSize : AtomicHeader.SIZE + 1;

                    System.Seek(pos, SeekOrigin.Begin);
                    System.Write(ms.GetBuffer(), 0, (int)ms.Length);

                    //atomic write
                    header.LastFlush = new Ptr(pos, ms.Length);
                    header.Serialize(System);
                }

                currentVersion++;
            }
        }

        public void Close()
        {
            lock (SyncRoot)
            {
                System.Close();
                Data.Close();
            }
        }

        public IEnumerable<KeyValuePair<long, byte[]>> GetLatest(long atVersion)
        {
            List<KeyValuePair<long, Pointer>> list = new List<KeyValuePair<long, Pointer>>();

            lock (SyncRoot)
            {
                foreach (var kv in used.Union(reserved))
                {
                    var handle = kv.Key;
                    var pointer = kv.Value;

                    if (pointer.Version >= atVersion && pointer.Version < currentVersion)
                    {
                        list.Add(new KeyValuePair<long, Pointer>(handle, pointer));
                        pointer.RefCount++;
                    }
                }
            }

            foreach (var kv in list)
            {
                var handle = kv.Key;
                var pointer = kv.Value;

                byte[] buffer;
                lock (SyncRoot)
                {
                    buffer = InternalRead(pointer.Ptr.Position, pointer.Ptr.Size);
                    pointer.RefCount--;
                    if (pointer.IsReserved && pointer.RefCount <= 0)
                    {
                        space.Free(pointer.Ptr);
                        reserved.Remove(handle);
                    }
                }

                yield return new KeyValuePair<long, byte[]>(handle, buffer);
            }
        }

        public KeyValuePair<long, Ptr>[] GetUsedSpace()
        {
            lock (SyncRoot)
            {
                KeyValuePair<long, Ptr>[] array = new KeyValuePair<long, Ptr>[used.Count + reserved.Count];

                int idx = 0;
                foreach (var kv in used.Union(reserved))
                    array[idx++] = new KeyValuePair<long, Ptr>(kv.Value.Version, kv.Value.Ptr);

                return array;
            }
        }

        public long CurrentVersion
        {
            get
            {
                lock (SyncRoot)
                    return currentVersion;
            }
        }
    }
}
