using System;
using System.IO;
using System.Linq;
using System.Text;
using STSdb4.Data;
using STSdb4.WaterfallTree;
using STSdb4.Database;
using STSdb4.Database.Index;

namespace STSdb4.Remote
{
    ///<summary>
    ///--------------------- Message Exchange Protocol
    ///
    ///--------------------- Comments-----------------------------------
    ///format           : binary
    ///byte style       : LittleEndian
    ///string encoding  : Unicode (UTF-16) 
    ///string format    : string int size, byte[] Unicode (UTF-16)
    ///
    ///
    ///------------------------------------------------------------------
    ///int StructType
    ///Locator           : int PathCount, string PathName[]
    ///
    ///KeyDescriptor     : int TypeCount, PrimitiveTypeCode[] Types
    ///Compressions      : bool compressKeys, bool compressRecords
    ///CompareOptions    : 
    ///RecordDescriptor  : int TypeCount, PrimitiveTypeCode[] Types
    ///Compressions      : bool compressRecords
    ///
    ///Operations        : IndexPersistOperationCollection
    ///
    ///</summary>    

    public class Message
    {
        public IOperationCollection Operations { get; private set; }
        public ILocator Locator { get { return Operations.Locator; } }

        public Message(IOperationCollection operations)
        {
            Operations = operations;
        }

        public void Serialize(BinaryWriter writer)
        {
            Locator locator = (Locator)Operations.Locator;

            writer.Write(locator.StructureType);

            writer.Write(locator.Length);
            for (int i = 0; i < locator.Length; i++)
            {
                byte[] pathNameBytes = Encoding.Unicode.GetBytes(locator[i]);

                writer.Write(pathNameBytes.Length);
                writer.Write(pathNameBytes);
            }

            locator.KeyDescriptor.Serialize(writer);
            locator.RecordDescriptor.Serialize(writer);

            IndexPersistOperationCollection operationPersist = new IndexPersistOperationCollection(locator);
            operationPersist.Write(writer, Operations);
        }

        public static Message Deserialize(BinaryReader reader)
        {
            int structType = reader.ReadInt32();

            int pathCount = reader.ReadInt32();
            string[] path = new string[pathCount];
            for (int i = 0; i < pathCount; i++)
            {
                int sizeOfString = reader.ReadInt32();
                byte[] pathNameBytes = reader.ReadBytes(sizeOfString);
                path[i] = Encoding.Unicode.GetString(pathNameBytes);
            }

            KeyDescriptor keyDescriptor = KeyDescriptor.Deserialize(reader);
            RecordDescriptor recordDescriptor = RecordDescriptor.Deserialize(reader);

            ILocator locator = STSdb4.Database.Locator.Obtain(structType, keyDescriptor, recordDescriptor, path);

            IndexPersistOperationCollection persistOperations = new IndexPersistOperationCollection(locator);

            IOperationCollection operations = persistOperations.Read(reader);

            return new Message(operations);
        }
    }
}
