using System;

namespace RiskEngine.Contracts.Runtime
{
    public class DataProviderCompletedEventArgs: EventArgs
    {
        public DataProviderCompletedEventArgs()
        {
        }

        public DataProviderCompletedEventArgs(ProviderRuntimeResult runtimeResult)
        {
            RuntimeResult = runtimeResult;
        }
        public ProviderRuntimeResult RuntimeResult { get; set; }
    }
}
