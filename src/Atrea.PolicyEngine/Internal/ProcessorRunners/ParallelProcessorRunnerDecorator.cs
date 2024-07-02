using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal class ParallelProcessorRunnerDecorator<T> : BaseProcessorRunnerDecorator<T>
{
    private readonly IEnumerable<IAsyncProcessor<T>> _parallelProcessors;

    internal ParallelProcessorRunnerDecorator(
        IAsyncProcessorRunner<T> asyncProcessorRunner,
        IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        : base(
            asyncProcessorRunner) =>
        _parallelProcessors = parallelProcessors;

    protected override async Task RunProcessorsAsync(T item)
    {
        var tasks = _parallelProcessors.Select(processor => processor.ProcessAsync(item));

        await Task.WhenAll(tasks);
    }
}