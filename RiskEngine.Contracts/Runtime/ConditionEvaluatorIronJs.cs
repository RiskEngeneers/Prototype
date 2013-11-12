using System;
using System.Globalization;


namespace RiskEngine.Contracts.Runtime
{
    public class ConditionEvaluatorIronJS: IConditionEvaluator
    {
        public bool Evaluate(string conditionScript, IWorkflowRuntime runtime)
        {
            if (conditionScript == null)
                throw new ArgumentNullException("conditionScript");
            if (runtime == null)
                throw new ArgumentNullException("runtime");

            var context = new IronJS.Hosting.CSharp.Context();
            context.SetGlobal("input", runtime.Input);
            foreach (var providerRuntimeResult in runtime.ProviderResults)
            {
                if (providerRuntimeResult.ProviderStatus == EWorkflowProviderRuntimeStatus.Success)
                    context.SetGlobal(providerRuntimeResult.ProviderName, providerRuntimeResult.Result);
            }
            conditionScript = "(function(){ " + conditionScript + "})()";
            return context.Execute<bool>(conditionScript);
        }
    }
}
