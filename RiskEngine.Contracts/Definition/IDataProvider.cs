using System;

namespace RiskEngine.Contracts.Definition
{
    interface IDataProvider
    {
        string Name { get; }
        Type OutputType { get; }
        Type InputType { get; }
        object ProvideData(object input);
    }

    interface IDataProvider<TInput, TOutput>: IDataProvider
    {
        TOutput ProvideData(TInput input);
    }
}