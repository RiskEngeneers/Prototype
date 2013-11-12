using System;
using System.Threading.Tasks;

namespace RiskEngine.Contracts.Definition
{
    public abstract class DataProviderBaseAsync<TInput, TOutput>: IDataProviderAsync
    {
        public virtual string Name { get { return this.GetType().Name; } }
        
        public Type OutputType { get { return typeof (TInput); } }
        
        public Type InputType { get { return typeof (TOutput); } }
        
        public async Task<object> ProvideData(object input)
        {
            var output = await ProvideData((TInput) input);
            return output;
        }

        public abstract Task<TOutput> ProvideData(TInput input);
    }
}
