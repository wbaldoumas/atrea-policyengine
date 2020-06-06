using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    public class ParallelProcessorRunnerDecorator<T> : BaseProcessorRunnerDecorator<T>
    {
        private readonly IEnumerable<IAsyncProcessor<T>> _parallelProcessors;

        internal ParallelProcessorRunnerDecorator(
            IAsyncProcessorRunner<T> asyncProcessorRunner,
            IEnumerable<IAsyncProcessor<T>> parallelProcessors) : base(
            asyncProcessorRunner) =>
            _parallelProcessors = parallelProcessors;

        protected override async Task RunProcessors(T item)
        {
            var tasks = _parallelProcessors.Select(processor => processor.ProcessAsync(item));

            await Task.WhenAll(tasks);
        }
    }
}