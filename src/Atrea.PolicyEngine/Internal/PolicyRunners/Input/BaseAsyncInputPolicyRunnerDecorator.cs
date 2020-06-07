using System;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    public abstract class BaseAsyncInputPolicyRunnerDecorator<T> : IAsyncInputPolicyRunner<T>
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

            switch (result)
            {
                case InputPolicyResult.Accept:
                    return InputPolicyResult.Accept;
                case InputPolicyResult.Reject:
                    return InputPolicyResult.Reject;
                case InputPolicyResult.Continue:
                    return await EvaluateInputPolicies(item);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected abstract Task<InputPolicyResult> EvaluateInputPolicies(T item);
    }
}