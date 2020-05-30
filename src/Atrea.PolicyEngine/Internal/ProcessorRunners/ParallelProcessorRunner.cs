using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    internal class ParallelProcessorRunner<T> : IParallelProcessorRunner<T>
    {
        private readonly IEnumerable<IAsyncProcessor<T>> _processors;

        public ParallelProcessorRunner(IEnumerable<IAsyncProcessor<T>> processors)
        {
            _processors = processors;
        }

        public async Task ProcessAsync(T item)
        {
            var tasks = _processors.Select(processor => processor.ProcessAsync(item));

            await Task.WhenAll(tasks);
        }
    }
}