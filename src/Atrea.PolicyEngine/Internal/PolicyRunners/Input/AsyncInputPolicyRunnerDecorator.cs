using Atrea.PolicyEngine.Policies.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal class AsyncInputPolicyRunnerDecorator<T> : BaseAsyncInputPolicyRunnerDecorator<T>
    {
        private readonly IEnumerable<IAsyncInputPolicy<T>> _asyncInputPolicies;

        public AsyncInputPolicyRunnerDecorator(
            IAsyncInputPolicyRunner<T> asyncInputPolicyRunner, 
            IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies) : base(asyncInputPolicyRunner)
        {
            _asyncInputPolicies = asyncInputPolicies;
        }

        protected override async Task<InputPolicyResult> EvaluateInputPolicies(T item)
        {
            foreach (var inputPolicy in _asyncInputPolicies)
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