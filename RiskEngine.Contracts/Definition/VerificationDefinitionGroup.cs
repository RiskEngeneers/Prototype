using System.Collections.Generic;

namespace RiskEngine.Contracts.Definition
{
    public class VerificationDefinitionGroup: VerificationDefinition
    {
        public IEnumerable<VerificationDefinition> SubVerifications { get; set; } 
    }
}