using STSdb4.Data;
using STSdb4.Database;
using STSdb4.Database.Operations;
using STSdb4.Remote;
using STSdb4.General.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using STSdb4.WaterfallTree;
using STSdb4.General.Communication;

namespace STSdb4.Remote
{
    public class StorageEngineServer
    {
        private CancellationTokenSource ShutdownTokenSource;
        private Thread Worker;

        public readonly IStorageEngine StorageEngine;
        public readonly TcpServer TcpServer;

        public StorageEngineServer(IStorageEngine storageEngine, TcpServer tcpServer)
        {
            if (storageEngine == null)
                throw new ArgumentNullException("storageEngine");
            if (tcpServer == null)
                throw new ArgumentNullException("tcpServer");

            StorageEngine = storageEngine;
            TcpServer = tcpServer;
        }

        public void Start()
        {
            Stop();

            ShutdownTokenSource = new CancellationTokenSource();

            Worker = new Thread(DoWork);
            Worker.Start();
        }

        public void Stop()
        {
            if (!IsWorking)
                return;

            ShutdownTokenSource.Cancel(false);

            Thread thread = Worker;
            if (thread != null)
            {
                if (!thread.Join(5000))
                    thread.Abort();
            }
        }

        public bool IsWorking
        {
            get { return Worker != null; }
        }

        private void DoWork()
        {
            try
            {
                TcpServer.Start();

                while (!ShutdownTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        KeyValuePair<ServerConnection,Packet> order = TcpServer.RecievedPackets.Take(ShutdownTokenSource.Token);
                        Task.Factory.StartNew(PacketExecute, order);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (Exception exc)
                    {
                        TcpServer.LogError(exc);
                    }
                }
            }
            catch(Exception exc)
            {
                TcpServer.LogError(exc);
            }
            finally
            {
                TcpServer.Stop();

                Worker = null;
            }
        }

        private void PacketExecute(object state)
        {
            try
            {
                KeyValuePair<ServerConnection, Packet> order = (KeyValuePair<ServerConnection, Packet>)state;

                BinaryReader reader = new BinaryReader(order.Value.Request);
                Message msgRequest = Message.Deserialize(reader);

                MemoryStream ms = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(ms);

                IOperationCollection asyncOperations = new OperationCollection(msgRequest.Locator, msgRequest.Operations.Count);
                IOperationCollection resultsOperations = new OperationCollection(msgRequest.Locator, 1);
                var index = StorageEngine.OpenXIndex(msgRequest.Locator.KeyDescriptor, msgRequest.Locator.RecordDescriptor, msgRequest.Locator.Name);

                foreach (var operation in msgRequest.Operations)
                {
                    try
                    {
                        if (!operation.IsSynchronous)
                            asyncOperations.Add(operation);
                        else
                        {
                            StorageEngine.Execute(asyncOperations);
                            asyncOperations.Clear();

                            switch (operation.Code)
                            {
                                case OperationCode.TRY_GET:
                                    {
                                        IData record = null;
                                        index.TryGet(operation.FromKey, out record);
                                        resultsOperations.Add(new TryGetOperation(operation.FromKey, record));
                                    }
                                    break;
                                case OperationCode.FORWARD:
                                    {
                                        var op = (ForwardOperation)operation;
                                        List<KeyValuePair<IData, IData>> forward = index.Forward(op.FromKey, op.FromKey != null, op.ToKey, op.ToKey != null).Take(op.PageCount).ToList();

                                        ForwardOperation opResult = new ForwardOperation(0, op.FromKey, op.ToKey, forward);
                                        resultsOperations.Add(opResult);
                                    }
                                    break;
                                case OperationCode.BACKWARD:
                                    {
                                        var op = (BackwardOperation)operation;
                                        List<KeyValuePair<IData, IData>> backward = index.Backward(op.FromKey, op.FromKey != null, op.ToKey, op.ToKey != null).Take(op.PageCount).ToList();

                                        BackwardOperation opResult = new BackwardOperation(0, op.FromKey, op.ToKey, backward);
                                        resultsOperations.Add(opResult);
                                    }
                                    break;
                                case OperationCode.COUNT:
                                    {
                                        resultsOperations.Add(new CountOperation(index.Count()));
                                    }
                                    break;
                                case OperationCode.FIND_NEXT:
                                    {
                                        var kv = index.FindNext(operation.FromKey);
                                        resultsOperations.Add(new FindNextOperation(operation.FromKey, kv));
                                    }
                                    break;
                                case OperationCode.FIND_AFTER:
                                    {
                                        var kv = index.FindAfter(operation.FromKey);
                                        resultsOperations.Add(new FindAfterOperation(operation.FromKey, kv));
                                    }
                                    break;
                                case OperationCode.FIND_PREV:
                                    {
                                        var kv = index.FindPrev(operation.FromKey);
                                        resultsOperations.Add(new FindPrevOperation(operation.FromKey, kv));
                                    }
                                    break;
                                case OperationCode.FIND_BEFORE:
                                    {
                                        var kv = index.FindBefore(operation.FromKey);
                                        resultsOperations.Add(new FindBeforeOperation(operation.FromKey, kv));
                                    }
                                    break;
                                case OperationCode.FIRST_ROW:
                                    {
                                        var kv = index.FirstRow;
                                        resultsOperations.Add(new FirstRowOperation(kv));
                                    }
                                    break;
                                case OperationCode.LAST_ROW:
                                    {
                                        var kv = index.LastRow;
                                        resultsOperations.Add(new LastRowOperation(kv));
                                    }
                                    break;
                                case OperationCode.STORAGE_ENGINE_COMMIT:
                                    {
                                        StorageEngine.Commit();
                                        resultsOperations.Add(new StorageEngineCommitOperation());
                                    }
                                    break;
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        resultsOperations.Add(new ExceptionOperation(exc.Message));
                    }
                }

                if (asyncOperations.Count > 0)
                    StorageEngine.Execute(asyncOperations);
                index.Flush();

                Message msgResponse = new Message(resultsOperations);
                msgResponse.Serialize(writer);

                ms.Position = 0;
                order.Value.Response = ms;
                order.Key.PendingPackets.Add(order.Value);
            }
            catch (Exception exc)
            {
                TcpServer.LogError(exc);
            }
        }
    }
}
