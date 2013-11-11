using System;
using System.Collections;
using System.Collections.Generic;

namespace RiskEngine.Contracts.Definition
{
    public interface IWorkflowDataProvider
    {
        string Name { get; }
        Type OutputType { get; }
        IEnumerable<string> RequiredProviders { get; }
        object ProvideDataObject();
    }

    interface IWorkflowDataProvider<TOutput>: IWorkflowDataProvider
    {
        TOutput ProvideData();
    }
}