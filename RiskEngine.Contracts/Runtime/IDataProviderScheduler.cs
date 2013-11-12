using System;
using RiskEngine.Contracts.Definition;

namespace RiskEngine.Contracts.Runtime
{
    public interface IDataProviderScheduler
    {
        void Schedule(IDataProvider dataProvider, object inputData);
        event EventHandler<DataProviderCompletedEventArgs> DataReceived;
    }
}