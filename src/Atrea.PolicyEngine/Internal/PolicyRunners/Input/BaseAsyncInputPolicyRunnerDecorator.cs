using System;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal abstract class BaseAsyncInputPolicyRunnerDecorator<T> : IAsyncInputPolicyRunner<T>
    {
        private readonly IAsyncInputPolicyRunner<T> _asyncInputPolicyRunner;

        private protected BaseAsyncInputPolicyRunnerDecorator(IAsyncInputPolicyRunner<T> asyncInputPolicyRunner) =>
            _asyncInputPolicyRunner = asyncInputPolicyRunner;

        public async Task<InputPolicyResult> ShouldProcessAsync(T item)
        {
            var result = InputPolicyResult.Continue;

            if (!(_asyncInputPolicyRunner is null))
            {
                result = await _asyncInputPolicyRunner.ShouldProcessAsync(item);
            }

            if (result == InputPolicyResult.Accept)
            {
                return InputPolicyResult.Accept;
            }

            if (result == InputPolicyResult.Reject)
            {
                return InputPolicyResult.Reject;
            }

            if (result == InputPolicyResult.Continue)
            {
                return await EvaluateInputPolicies(item);
            }

            throw new ArgumentOutOfRangeException(nameof(result), $"Input policies generated invalid {nameof(InputPolicyResult)}.");
        }

        protected abstract Task<InputPolicyResult> EvaluateInputPolicies(T item);
    }
}