using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Output;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal class ParallelOutputPolicyRunner<T> : IParallelOutputPolicyRunner<T>
    {
        private readonly IEnumerable<IAsyncOutputPolicy<T>> _outputPolicies;

        public ParallelOutputPolicyRunner(IEnumerable<IAsyncOutputPolicy<T>> outputPolicies)
        {
            _outputPolicies = outputPolicies;
        }

        public async Task ApplyAsync(T item)
        {
            var tasks = _outputPolicies.Select(outputPolicy => outputPolicy.ApplyAsync(item));

            await Task.WhenAll(tasks);
        }
    }
}