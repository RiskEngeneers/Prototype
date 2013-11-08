using System.Collections.Generic;

namespace RiskEngine.Contracts.Definition
{
    interface IScriptedVerificationDefinition: IVerificationDefinition
    {
        IEnumerable<Rule> Rules { get; }
    }
}