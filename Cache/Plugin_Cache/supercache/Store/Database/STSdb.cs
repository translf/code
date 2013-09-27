using STSdb4.General.Communication;
using STSdb4.General.IO;
using STSdb4.Remote;
using STSdb4.Storage;
using STSdb4.WaterfallTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;

namespace STSdb4.Database
{
    public static class STSdb
    {
        private static IStorageEngine FromStream(Stream system, Stream data, long initialFreeSize, bool useCompression = false)
        {
            IHeap heap = new Heap(system, data, initialFreeSize, useCompression);

            return new StorageEngine(heap);
        }

        public static IStorageEngine FromFile(string systemFileName, string dataFileName, bool useCompression = false)
        {
            var system = new OptimizedFileStream(systemFileName, FileMode.OpenOrCreate);
            var data = new OptimizedFileStream(dataFileName, FileMode.OpenOrCreate);
            long initialFreeSize = IOUtils.GetTotalSpace(Path.GetPathRoot(Path.GetFullPath(dataFileName)));

            return STSdb.FromStream(system, data, initialFreeSize, useCompression);
        }

        public static IStorageEngine FromMemory(bool useCompression = false)
        {
            var system = new MemoryStream();
            var data = new MemoryStream();

            long initialFreeSize = 0;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(new ObjectQuery("SELECT * From Win32_ComputerSystem"));
            foreach (var item in searcher.Get())
                initialFreeSize = long.Parse(item["TotalPhysicalMemory"].ToString());

            return STSdb.FromStream(system, data, initialFreeSize, useCompression);
        }

        public static IStorageEngine FromNetwork(string host, int port = 7182)
        {
            return new StorageEngineClient(host, port);
        }

        public static StorageEngineServer CreateServer(IStorageEngine engine, int port = 7182)
        {
            TcpServer server = new TcpServer(port);
            StorageEngineServer engineServer = new StorageEngineServer(engine, server);

            return engineServer;
        }
    }
}
