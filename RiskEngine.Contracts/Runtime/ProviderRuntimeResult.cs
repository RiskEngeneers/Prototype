namespace RiskEngine.Contracts.Runtime
{
    public class ProviderRuntimeResult
    {
        public string ProviderName { get; private set; }
        public EWorkflowProviderRuntimeStatus ProviderStatus { get; private set; }
        public object Details { get; private set; }
        public object Result { get; private set; }
    }
}