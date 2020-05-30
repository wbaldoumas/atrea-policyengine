using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    internal class AggregateAsyncProcessorRunner<T> : IAsyncProcessorRunner<T>
    {
        private readonly IAsyncProcessorRunner<T> _asyncProcessorRunner;
        private readonly IParallelProcessorRunner<T> _parallelProcessorRunner;
        private readonly IProcessorRunner<T> _processorRunner;

        public AggregateAsyncProcessorRunner(
            IProcessorRunner<T> processorRunner,
            IAsyncProcessorRunner<T> asyncProcessorRunner,
            IParallelProcessorRunner<T> parallelProcessorRunner)
        {
            _processorRunner = processorRunner;
            _asyncProcessorRunner = asyncProcessorRunner;
            _parallelProcessorRunner = parallelProcessorRunner;
        }

        public async Task ProcessAsync(T item)
        {
            _processorRunner.Process(item);
            await _asyncProcessorRunner.ProcessAsync(item);
            await _parallelProcessorRunner.ProcessAsync(item);
        }
    }
}