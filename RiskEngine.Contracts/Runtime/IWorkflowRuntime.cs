using RiskEngine.Contracts.Definition;

namespace RiskEngine.Contracts.Runtime
{
    interface IWorkflowRuntime<TInput>
    {
        TInput Input { get; }
        IWorkflowDefinition Definition { get; }
        ERuntimeStatus RuntimeStatus { get; }
        void DataReceived(ProviderRuntimeResult providerResult);
        void Start();
        void Resume();
    }
}