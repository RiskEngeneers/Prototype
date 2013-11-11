namespace RiskEngine.Contracts.Runtime
{
    public class ProviderRuntimeResult
    {
        public string ProviderName { get; set; }
        public EWorkflowProviderRuntimeStatus ProviderStatus { get; set; }
        public object Details { get;  set; }
        public object Result { get;  set; }
    }
}