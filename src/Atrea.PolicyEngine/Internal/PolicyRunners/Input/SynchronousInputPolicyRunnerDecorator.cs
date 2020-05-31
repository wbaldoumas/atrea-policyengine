using Atrea.PolicyEngine.Policies.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal class SynchronousInputPolicyRunnerDecorator<T> : BaseAsyncInputPolicyRunnerDecorator<T>
    {
        private readonly IEnumerable<IInputPolicy<T>> _inputPolicies;

        public SynchronousInputPolicyRunnerDecorator(
            IAsyncInputPolicyRunner<T> asyncInputPolicyRunner,
            IEnumerable<IInputPolicy<T>> inputPolicies) : base(asyncInputPolicyRunner)
        {
            _inputPolicies = inputPolicies;
        }

        protected override Task<InputPolicyResult> EvaluateInputPolicies(T item)
        {
            var task = new Task<InputPolicyResult>(() =>
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
            });

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }
    }
}