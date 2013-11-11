using System.Collections.Generic;

namespace RiskEngine.Contracts.Definition
{
    public class VerificationDefinition 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public IEnumerable<string> RequiredProviders { get; set; }
    }
}