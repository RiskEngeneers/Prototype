using System;
using System.Collections.Generic;
using System.Globalization;


namespace RiskEngine.Contracts.Runtime
{
    public class ConditionEvaluatorIronPython: IConditionEvaluator
    {
        public bool Evaluate(string conditionScript, IWorkflowRuntime runtime)
        {
            if (conditionScript == null)
                throw new ArgumentNullException("conditionScript");
            if (runtime == null)
                throw new ArgumentNullException("runtime");

            var inputs = new Dictionary<string, object> { {"input", runtime.Input }};
            foreach (var providerRuntimeResult in runtime.ProviderResults)
            {
                if (providerRuntimeResult.ProviderStatus == EWorkflowProviderRuntimeStatus.Success)
                    inputs.Add(providerRuntimeResult.ProviderName, providerRuntimeResult.Result);
            }
            var engine = IronPython.Hosting.Python.CreateEngine();
            var scope = engine.CreateScope(inputs);
            return engine.Execute<bool>(conditionScript, scope);
        }
    }
}
