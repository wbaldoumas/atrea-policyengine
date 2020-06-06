using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Output;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal class AsyncOutputPolicyRunnerDecorator<T> : BaseAsyncOutputPolicyRunnerDecorator<T>
    {
        private readonly IEnumerable<IAsyncOutputPolicy<T>> _asyncAsyncOutputPolicies;

        public AsyncOutputPolicyRunnerDecorator(
            IAsyncOutputPolicyRunner<T> asyncOutputPolicyRunner,
            IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies) : base(asyncOutputPolicyRunner) =>
            _asyncAsyncOutputPolicies = asyncOutputPolicies;

        protected override async Task ApplyOutputPolicies(T item)
        {
            foreach (var asyncOutputPolicy in _asyncAsyncOutputPolicies)
            {
                await asyncOutputPolicy.ApplyAsync(item);
            }
        }
    }
}