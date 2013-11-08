namespace RiskEngine.Contracts.Definition
{
    internal interface IVerificationDefinition
    {
        string Name { get; }
        string Description { get; }
        string Condition { get; }
        string[] RequiredProviders { get; }
    }
}