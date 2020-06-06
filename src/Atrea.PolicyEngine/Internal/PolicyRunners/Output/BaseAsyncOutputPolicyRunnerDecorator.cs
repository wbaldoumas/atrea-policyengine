using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal abstract class BaseAsyncOutputPolicyRunnerDecorator<T> : IAsyncOutputPolicyRunner<T>
    {
        private readonly IAsyncOutputPolicyRunner<T> _asyncOutputPolicyRunner;

        protected BaseAsyncOutputPolicyRunnerDecorator(IAsyncOutputPolicyRunner<T> asyncOutputPolicyRunner) =>
            _asyncOutputPolicyRunner = asyncOutputPolicyRunner;

        public async Task ApplyAsync(T item)
        {
            if (!(_asyncOutputPolicyRunner is null))
            {
                await _asyncOutputPolicyRunner.ApplyAsync(item);
            }

            await ApplyOutputPolicies(item);
        }

        protected abstract Task ApplyOutputPolicies(T item);
    }
}