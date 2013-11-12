using System;
using System.Threading.Tasks;

namespace RiskEngine.Contracts.Definition
{
    public abstract class DataProviderBase<TInput, TOutput>: IDataProvider
    {
        public abstract string Name { get; }
        
        public Type OutputType { get { return typeof (TInput); } }
        
        public Type InputType { get { return typeof (TOutput); } }
        
        public object ProvideData(object input)
        {
            var output = ProvideData((TInput) input);
            return output;
        }

        public abstract TOutput ProvideData(TInput input);
    }
}
