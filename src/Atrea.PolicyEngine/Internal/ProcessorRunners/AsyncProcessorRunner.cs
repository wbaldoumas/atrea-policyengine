using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    internal class AsyncProcessorRunner<T> : IAsyncProcessorRunner<T>
    {
        private readonly IEnumerable<IAsyncProcessor<T>> _processors;

        public AsyncProcessorRunner(IEnumerable<IAsyncProcessor<T>> processors)
        {
            _processors = processors;
        }

        public async Task ProcessAsync(T item)
        {
            foreach (var asyncProcessor in _processors)
            {
                await asyncProcessor.ProcessAsync(item);
            }
        }
    }
}