using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace STSdb4.Storage
{
    public class AtomicHeader
    {
        private const int POSITION = 0;

        /// <summary>
        /// http://en.wikipedia.org/wiki/Advanced_Format
        /// http://www.idema.org
        /// </summary>
        public const int SIZE = 4 * 1024;

        public const int MAX_TAG_DATA = 256;

        private byte[] tag;

        /// <summary>
        /// Last successful flush location.
        /// </summary>
        public Ptr LastFlush;

        public void Serialize(Stream system)
        {
            byte[] buffer = new byte[SIZE];

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryWriter bw = new BinaryWriter(ms);

                //last flush location
                LastFlush.Serialize(bw);

                //tag
                if (Tag == null)
                    bw.Write((int)-1);
                else
                {
                    bw.Write(Tag.Length);
                    bw.Write(Tag);
                }
            }

            system.Seek(POSITION, SeekOrigin.Begin);
            system.Write(buffer, 0, buffer.Length);
        }

        public static AtomicHeader Deserialize(Stream system)
        {
            AtomicHeader header = new AtomicHeader();

            system.Seek(POSITION, SeekOrigin.Begin);
            byte[] buffer = new byte[SIZE];

            if (system.Read(buffer, 0, buffer.Length) != SIZE)
                return header;

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);

                //last flush location
                header.LastFlush = Ptr.Deserialize(br);

                //tag
                int tagLength = br.ReadInt32();
                header.Tag = tagLength >= 0 ? br.ReadBytes(tagLength) : null;
            }

            return header;
        }

        public byte[] Tag
        {
            get { return tag; }
            set
            {
                if (value != null && value.Length > MAX_TAG_DATA)
                    throw new ArgumentException("Tag");

                tag = value;
            }
        }
    }
}
