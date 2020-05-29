using System;
using System.Collections.Generic;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal class InputPolicyRunner<T> : IInputPolicyRunner<T>
    {
        private readonly IEnumerable<IInputPolicy<T>> _inputPolicies;

        public InputPolicyRunner(IEnumerable<IInputPolicy<T>> inputPolicies)
        {
            _inputPolicies = inputPolicies;
        }

        public InputPolicyResult ShouldProcess(T item)
        {
            foreach (var inputPolicy in _inputPolicies)
            {
                switch (inputPolicy.ShouldProcess(item))
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