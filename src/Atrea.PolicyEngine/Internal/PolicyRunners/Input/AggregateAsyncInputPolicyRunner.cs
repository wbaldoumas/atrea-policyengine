using System;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal class AggregateAsyncInputPolicyRunner<T> : IAsyncInputPolicyRunner<T>
    {
        private readonly IAsyncInputPolicyRunner<T> _asyncInputPolicyRunner;
        private readonly IInputPolicyRunner<T> _inputPolicyRunner;

        public AggregateAsyncInputPolicyRunner(
            IInputPolicyRunner<T> inputPolicyRunner,
            IAsyncInputPolicyRunner<T> asyncInputPolicyRunner)
        {
            _inputPolicyRunner = inputPolicyRunner;
            _asyncInputPolicyRunner = asyncInputPolicyRunner;
        }

        public async Task<InputPolicyResult> ShouldProcessAsync(T item)
        {
            var inputPolicyResult = _inputPolicyRunner.ShouldProcess(item);

            return inputPolicyResult switch
            {
                InputPolicyResult.Accept => InputPolicyResult.Accept,
                InputPolicyResult.Reject => InputPolicyResult.Reject,
                InputPolicyResult.Continue => await _asyncInputPolicyRunner.ShouldProcessAsync(item),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}