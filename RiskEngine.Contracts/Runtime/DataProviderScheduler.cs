using System;
using System.Threading.Tasks;
using RiskEngine.Contracts.Definition;

namespace RiskEngine.Contracts.Runtime
{
    public class DataProviderScheduler : IDataProviderScheduler
    {
        public async void Schedule(IDataProviderAsync dataProvider, object inputData)
        {
            try
            {
                var result = await dataProvider.ProvideData(inputData);
                OnDataReceived(new ProviderRuntimeResult
                {
                    ProviderName = dataProvider.Name,
                    ProviderStatus = EWorkflowProviderRuntimeStatus.Success,
                    Result = result,
                });

            }
            catch (DataProviderException exc)
            {
                OnDataReceived(new ProviderRuntimeResult
                {
                    ProviderName = dataProvider.Name,
                    ProviderStatus = EWorkflowProviderRuntimeStatus.Faulted,
                    Details = exc,
                });
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public void Schedule(IDataProvider dataProvider, object inputData)
        {
            var task = new Task<object>(dataProvider.ProvideData, inputData);
            task.ContinueWith(t =>
            {
                var result = new ProviderRuntimeResult {ProviderName = dataProvider.Name};
                if (t.IsFaulted)
                {
                    result.Details = t.Exception;
                    result.ProviderStatus = EWorkflowProviderRuntimeStatus.Faulted;
                }
                else
                {
                    result.Result = t.Result;
                    result.ProviderStatus = EWorkflowProviderRuntimeStatus.Success;
                }
                OnDataReceived(result);
            });
            task.Start();
        }

        public event EventHandler<DataProviderCompletedEventArgs> DataReceived;

        protected virtual void OnDataReceived(ProviderRuntimeResult runtimeResult)
        {
            var handler = DataReceived;
            if (handler != null)
                handler(this, new DataProviderCompletedEventArgs(runtimeResult));
        }
    }
}