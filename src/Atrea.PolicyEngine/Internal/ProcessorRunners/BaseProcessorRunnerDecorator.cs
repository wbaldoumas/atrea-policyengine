using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    public abstract class BaseProcessorRunnerDecorator<T> : IAsyncProcessorRunner<T>
    {
        private readonly IAsyncProcessorRunner<T> _asyncProcessorRunner;

        private protected BaseProcessorRunnerDecorator(IAsyncProcessorRunner<T> asyncProcessorRunner)
        {
            _asyncProcessorRunner = asyncProcessorRunner;
        }

        public async Task ProcessAsync(T item)
        {
            if (!(_asyncProcessorRunner is null))
            {
                await _asyncProcessorRunner.ProcessAsync(item);
            }

            await RunProcessors(item);
        }

        protected abstract Task RunProcessors(T item);
    }
}