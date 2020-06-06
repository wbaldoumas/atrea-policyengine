using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Output;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal class SynchronousOutputPolicyRunnerDecorator<T> : BaseAsyncOutputPolicyRunnerDecorator<T>
    {
        private readonly IEnumerable<IOutputPolicy<T>> _outputPolicies;

        public SynchronousOutputPolicyRunnerDecorator(
            IAsyncOutputPolicyRunner<T> asyncOutputPolicyRunner,
            IEnumerable<IOutputPolicy<T>> outputPolicies) : base(asyncOutputPolicyRunner) =>
            _outputPolicies = outputPolicies;

        protected override Task ApplyOutputPolicies(T item)
        {
            var task = new Task(() =>
            {
                foreach (var outputPolicy in _outputPolicies)
                {
                    outputPolicy.Apply(item);
                }
            });

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }
    }
}