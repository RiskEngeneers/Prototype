using System.Collections.Generic;

namespace RiskEngine.Contracts.Definition
{
    public class ScriptedVerificationDefinition: VerificationDefinition
    {
        public IEnumerable<Rule> Rules { get; set; }
    }
}