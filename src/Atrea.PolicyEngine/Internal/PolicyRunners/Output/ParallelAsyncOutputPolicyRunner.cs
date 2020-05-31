using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Output;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal class ParallelAsyncOutputPolicyRunner<T> : BaseAsyncOutputPolicyRunnerDecorator<T>
    {
        private readonly IEnumerable<IAsyncOutputPolicy<T>> _parallelOutputPolicies;

        public ParallelAsyncOutputPolicyRunner(
            IAsyncOutputPolicyRunner<T> asyncOutputPolicyRunner,
            IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies) : base(asyncOutputPolicyRunner)
        {
            _parallelOutputPolicies = parallelOutputPolicies;
        }

        protected override async Task ApplyOutputPolicies(T item)
        {
            var tasks = _parallelOutputPolicies.Select(outputPolicy => outputPolicy.ApplyAsync(item));

            await Task.WhenAll(tasks);
        }
    }
}