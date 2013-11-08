using System.Collections.Generic;

namespace RiskEngine.Contracts.Definition
{
    interface IVerificationDefinitionGroup: IVerificationDefinition
    {
        IEnumerable<IVerificationDefinition> SubVerifications { get; }     
    }
}