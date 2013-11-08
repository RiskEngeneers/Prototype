using RiskEngine.Contracts.Runtime;

namespace RiskEngine.Contracts.Definition
{
    public class Rule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public EVerificationResult SuccessResult { get; set; }
    }
}