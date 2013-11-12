using System.Collections;
using System.Collections.Generic;
using RiskEngine.Contracts.Definition;

namespace RiskEngine.Contracts.Runtime
{
    public interface IWorkflowRuntime
    {
        object Input { get; }
        WorkflowDefinition Definition { get; }
        ERuntimeStatus RuntimeStatus { get; }
        IEnumerable<ProviderRuntimeResult> ProviderResults { get; }
        void DataReceived(ProviderRuntimeResult providerResult);
        void Start();
        void ResumeExecution();
    }
}