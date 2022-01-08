using Atrea.PolicyEngine.Policies.Output;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal class ParallelOutputPolicyRunner<T> : BaseAsyncOutputPolicyRunnerDecorator<T>
    {
        private readonly IEnumerable<IAsyncOutputPolicy<T>> _parallelOutputPolicies;

        public ParallelOutputPolicyRunner(
            IAsyncOutputPolicyRunner<T> asyncOutputPolicyRunner,
            IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
            : base(asyncOutputPolicyRunner) =>
            _parallelOutputPolicies = parallelOutputPolicies;

        protected override async Task ApplyOutputPolicies(T item)
        {
            var tasks = _parallelOutputPolicies.Select(outputPolicy => outputPolicy.ApplyAsync(item));

            await Task.WhenAll(tasks);
        }
    }
}