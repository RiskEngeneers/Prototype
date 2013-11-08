using System.Collections.Generic;

namespace RiskEngine.Contracts.Runtime
{
    public class VerificationResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EVerificationResult Status { get; set; }
        public IEnumerable<VerificationResult> SubResults { get; set; }
    }
}
