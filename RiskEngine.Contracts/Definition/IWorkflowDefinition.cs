using System;
using System.Collections.Generic;

namespace RiskEngine.Contracts.Definition
{
    interface IWorkflowDefinition
    {
        string Name { get; }
        Type InputType { get; }
        IEnumerable<IWorkflowDataProvider> DataProviders { get; }
        IEnumerable<IVerificationDefinition> CheckItems { get; }
    }
}