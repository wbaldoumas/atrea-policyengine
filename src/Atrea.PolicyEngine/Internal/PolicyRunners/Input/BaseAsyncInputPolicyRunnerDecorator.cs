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

            return result switch
            {
                InputPolicyResult.Accept => InputPolicyResult.Accept,
                InputPolicyResult.Reject => InputPolicyResult.Reject,
                InputPolicyResult.Continue => await EvaluateInputPolicies(item),
                _ => throw new ArgumentOutOfRangeException(nameof(result),
                    $"Input policies generated invalid {nameof(InputPolicyResult)}.")
            };
        }

        protected abstract Task<InputPolicyResult> EvaluateInputPolicies(T item);
    }
}