namespace RiskEngine.Contracts.Runtime
{
    public interface IConditionEvaluator
    {
        bool Evaluate(string conditionScript, IWorkflowRuntime runtime);
    }
}