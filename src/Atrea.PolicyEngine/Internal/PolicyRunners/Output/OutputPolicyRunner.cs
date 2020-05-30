using System.Collections.Generic;
using Atrea.PolicyEngine.Policies.Output;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal class OutputPolicyRunner<T> : IOutputPolicyRunner<T>
    {
        private readonly IEnumerable<IOutputPolicy<T>> _outputPolicies;

        public OutputPolicyRunner(IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _outputPolicies = outputPolicies;
        }

        public void Apply(T item)
        {
            foreach (var outputPolicy in _outputPolicies)
            {
                outputPolicy.Apply(item);
            }
        }
    }
}