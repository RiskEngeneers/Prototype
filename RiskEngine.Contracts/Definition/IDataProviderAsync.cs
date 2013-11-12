using System;
using System.Threading.Tasks;

namespace RiskEngine.Contracts.Definition
{
    public interface IDataProviderAsync
    {
        string Name { get; }
        Type OutputType { get; }
        Type InputType { get; }
        Task<object> ProvideData(object input);
    }
}