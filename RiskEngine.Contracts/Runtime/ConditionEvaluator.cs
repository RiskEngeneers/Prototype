using System;
using System.Globalization;
using Noesis.Javascript;

namespace RiskEngine.Contracts.Runtime
{
    public class ConditionEvaluator: IConditionEvaluator
    {


        public bool Evaluate(string conditionScript, IWorkflowRuntime runtime)
        {
            if (conditionScript == null)
                throw new ArgumentNullException("conditionScript");
            if (runtime == null)
                throw new ArgumentNullException("runtime");

            using (var scriptContext = new JavascriptContext())
            {
                scriptContext.SetParameter("input", runtime.Input);
                foreach (var providerRuntimeResult in runtime.ProviderResults)
                {
                    if (providerRuntimeResult.ProviderStatus == EWorkflowProviderRuntimeStatus.Success)
                        scriptContext.SetParameter(providerRuntimeResult.ProviderName, providerRuntimeResult.Result);
                }
                conditionScript = "var result = (function() {" + conditionScript + "})()";
                scriptContext.Run(conditionScript);
                return Convert.ToBoolean(scriptContext.GetParameter("result"), CultureInfo.InvariantCulture);
            }
        }
    }
}
