using Atrea.PolicyEngine.Policies.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal class ParallelInputPolicyRunnerDecorator<T> : BaseAsyncInputPolicyRunnerDecorator<T>
    {
        private readonly IEnumerable<IAsyncInputPolicy<T>> _parallelAsyncInputPolicies;

        internal ParallelInputPolicyRunnerDecorator(
            IAsyncInputPolicyRunner<T> asyncInputPolicyRunner,
            IEnumerable<IAsyncInputPolicy<T>> parallelAsyncInputPolicies)
            : base(
            asyncInputPolicyRunner) =>
            _parallelAsyncInputPolicies = parallelAsyncInputPolicies;

        protected override async Task<InputPolicyResult> EvaluateInputPolicies(T item)
        {
            var tasks = _parallelAsyncInputPolicies.Select(inputPolicy => inputPolicy.ShouldProcessAsync(item));

            var inputPolicyResults = (await Task.WhenAll(tasks)).ToList();

            if (inputPolicyResults.Any(inputPolicyResult => inputPolicyResult == InputPolicyResult.Accept))
            {
                return InputPolicyResult.Accept;
            }

            return inputPolicyResults.Any(inputPolicyResult => inputPolicyResult == InputPolicyResult.Reject)
                ? InputPolicyResult.Reject
                : InputPolicyResult.Continue;
        }
    }
}