using System.Threading.Tasks;

namespace RiskEngine.Contracts.Runtime
{
    interface IWorkflowInvoker<TInput>
    {
        WorkflowOutput Execute(TInput input);
        Task<WorkflowOutput> ExecuteAsync(TInput input);
    }
}