using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output
{
    internal class AggregateAsyncOutputPolicyRunner<T> : IAsyncOutputPolicyRunner<T>
    {
        private readonly IAsyncOutputPolicyRunner<T> _asyncOutputPolicyRunner;
        private readonly IOutputPolicyRunner<T> _outputPolicyRunner;
        private readonly IParallelOutputPolicyRunner<T> _parallelOutputPolicyRunner;

        public AggregateAsyncOutputPolicyRunner(
            IOutputPolicyRunner<T> outputPolicyRunner,
            IAsyncOutputPolicyRunner<T> asyncOutputPolicyRunner,
            IParallelOutputPolicyRunner<T> parallelOutputPolicyRunner)
        {
            _outputPolicyRunner = outputPolicyRunner;
            _asyncOutputPolicyRunner = asyncOutputPolicyRunner;
            _parallelOutputPolicyRunner = parallelOutputPolicyRunner;
        }

        public async Task ApplyAsync(T item)
        {
            _outputPolicyRunner.Apply(item);
            await _asyncOutputPolicyRunner.ApplyAsync(item);
            await _parallelOutputPolicyRunner.ApplyAsync(item);
        }
    }
}