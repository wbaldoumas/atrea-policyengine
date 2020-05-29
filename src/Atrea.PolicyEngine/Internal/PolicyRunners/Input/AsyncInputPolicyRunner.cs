using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal class AsyncInputPolicyRunner<T> : IAsyncInputPolicyRunner<T>
    {
        private readonly IEnumerable<IAsyncInputPolicy<T>> _inputPolicies;

        public AsyncInputPolicyRunner(IEnumerable<IAsyncInputPolicy<T>> inputPolicies)
        {
            _inputPolicies = inputPolicies;
        }

        public async Task<InputPolicyResult> ShouldProcessAsync(T item)
        {
            foreach (var inputPolicy in _inputPolicies)
            {
                switch (await inputPolicy.ShouldProcessAsync(item))
                {
                    case InputPolicyResult.Accept:
                        return InputPolicyResult.Accept;
                    case InputPolicyResult.Reject:
                        return InputPolicyResult.Reject;
                    case InputPolicyResult.Continue:
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return InputPolicyResult.Continue;
        }
    }
}