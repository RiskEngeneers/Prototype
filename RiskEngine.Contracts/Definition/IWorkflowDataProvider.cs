using System;

namespace RiskEngine.Contracts.Definition
{
    interface IWorkflowDataProvider
    {
        string Name { get; }
        Type OutputType { get; }
        string[] RequiredProviders { get; }
        object ProvideDataObject();
    }

    interface IWorkflowDataProvider<TOutput>: IWorkflowDataProvider
    {
        TOutput ProvideData();
    }
}