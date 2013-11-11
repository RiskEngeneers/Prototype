using System;
using System.Collections.Generic;

namespace RiskEngine.Contracts.Definition
{
    public abstract class WorkflowDefinition
    {
        public string Name { get; set; }
        public abstract Type InputType { get; }
        public IEnumerable<IWorkflowDataProvider> DataProviders { get; set; }
        public IEnumerable<VerificationDefinition> Verifications { get; set; }
    }

    public class WorkflowDefinition<TInput> : WorkflowDefinition
    {
        public override Type InputType
        {
            get { return typeof (TInput); }
        }
    }
}