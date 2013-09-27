using System;
using System.IO;
using STSdb4.General.Extensions;
using STSdb4.Data;

namespace STSdb4.Database
{
    public class XStream : Stream
    {
        internal const int BLOCK_SIZE = 2 * 1024;

        private long position;

        public IIndex<IData, IData> Index { get; private set; }

        public XStream(IIndex<IData, IData> index)
        {
            Index = index;
        }

        #region Stream Members

        public override void Write(byte[] buffer, int offset, int count)
        {
            while (count > 0)
            {
                int chunk = Math.Min(BLOCK_SIZE - (int)(position % BLOCK_SIZE), count);

                IData key = new Data<long>(position);
                IData record = new Data<byte[]>(buffer.Middle(offset, chunk));
                Index[key] = record;

                position += chunk;
                offset += chunk;
                count -= chunk;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (offset + count > buffer.Length)
                throw new ArgumentException("offset + count > buffer.Length");

            long oldPosition = position;
            var fromKey = new Data<long>(position - position % BLOCK_SIZE);
            var toKey = new Data<long>(position + count - 1);
            int chunk;

            foreach (var kv in Index.Forward(fromKey, true, toKey, true))
            {
                Data<long> key = (Data<long>)kv.Key;
                Data<byte[]> rec = (Data<byte[]>)kv.Value;

                if (position >= key.Slot0)
                {
                    chunk = Math.Min(rec.Slot0.Length - (int)(position % BLOCK_SIZE), count);
                    Buffer.BlockCopy(rec.Slot0, (int)(position - key.Slot0), buffer, offset, chunk);
                }
                else
                {
                    chunk = (int)Math.Min(key.Slot0 - position, (long)count);
                    Array.Clear(buffer, offset, chunk);
                }

                position += chunk;
                offset += chunk;
                count -= chunk;
            }

            if (count > 0)
            {
                Array.Clear(buffer, offset, count);
                position += count;
            }

            return (int)(position - oldPosition);
        }

        public override void Flush()
        {
            Index.Flush();
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override long Length
        {
            get
            {
                foreach (var row in Index.Backward())
                {
                    var key = (Data<long>)row.Key;
                    var rec = (Data<byte[]>)row.Value;

                    return key.Slot0 + rec.Slot0.Length;
                }

                return 0;
            }
        }

        public override long Position
        {
            get { return position; }
            set { position = value; }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    position = offset;
                    break;
                case SeekOrigin.Current:
                    position += offset;
                    break;
                case SeekOrigin.End:
                    position = Length - 1 - offset;
                    break;
            }

            return position;
        }

        public override void SetLength(long value)
        {
            var length = Length;
            if (value == length)
                return;

            var oldPosition = this.position;
            try
            {
                if (value > length)
                {
                    Seek(value - 1, SeekOrigin.Begin);
                    Write(new byte[1] { 0 }, 0, 1);
                }
                else //if (value < length)
                {
                    Seek(value, SeekOrigin.Begin);
                    Zero(length - value);
                }
            }
            finally
            {
                Seek(oldPosition, SeekOrigin.Begin);
            }
        }

        #endregion

        public void Zero(long count)
        {
            var fromKey = new Data<long>(position);
            var toKey = new Data<long>(position + count - 1);
            Index.Delete(fromKey, toKey);

            position += count;
        }
    }
}
