using STSdb4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportFiles
{
    //TODO: remove it
    public class FlowTransformer<T>
    {
        public IDataTransformer<T> Transfromer { get; private set; }
        private int coreCount;

        public FlowTransformer(IDataTransformer<T> transformer)
        {
            Transfromer = transformer; 

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
                coreCount += int.Parse(item["NumberOfCores"].ToString());
        }

        private KeyValuePair<T, IData> Transform(T item)
        {
            try
            {
                return new KeyValuePair<T, IData>(item, Transfromer.ToIData(item));
            }
            catch
            {
                return new KeyValuePair<T, IData>(item, null);
            }
        }

        public IEnumerable<KeyValuePair<T, IData>> Transform(IEnumerable<T> flow)
        {
            return flow.AsParallel().AsOrdered().WithDegreeOfParallelism(coreCount).Select((row, data) => Transform(row));
        }
    }

    //TODO: move to STS.General.Extensions
    public static class IEnumerableExtensions2
    {
        public static IEnumerable<KeyValuePair<T, IData>> Transform<T>(this IEnumerable<T> flow, IDataTransformer<T> transformer)
        {
            FlowTransformer<T> flowTransformer = new FlowTransformer<T>(transformer);

            return flowTransformer.Transform(flow);
        }
    }
}
