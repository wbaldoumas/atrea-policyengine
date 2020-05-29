using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Output;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal class AsyncOutputPolicyRunner<T> : IAsyncOutputPolicyRunner<T>
    {
        private readonly IEnumerable<IAsyncOutputPolicy<T>> _outputPolicies;

        public AsyncOutputPolicyRunner(IEnumerable<IAsyncOutputPolicy<T>> outputPolicies)
        {
            _outputPolicies = outputPolicies;
        }

        public async Task ApplyAsync(T item)
        {
            foreach (var outputPolicy in _outputPolicies)
            {
                await outputPolicy.ApplyAsync(item);
            }
        }
    }
}