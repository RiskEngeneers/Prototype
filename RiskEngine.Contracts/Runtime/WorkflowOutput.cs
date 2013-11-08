using System.Collections.Generic;

namespace RiskEngine.Contracts.Runtime
{
    public class WorkflowOutput
    {
        public EVerificationResult Status { get; set; }
        public object Details { get; set; }
        public IEnumerable<VerificationResult> Results { get; set; }
    }
}