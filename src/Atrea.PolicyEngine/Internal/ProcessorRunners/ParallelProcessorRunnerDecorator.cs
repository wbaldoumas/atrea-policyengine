using Atrea.PolicyEngine.Internal.Extensions;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal sealed class ParallelProcessorRunnerDecorator<T>(
    IAsyncProcessorRunner<T>? asyncProcessorRunner,
    IEnumerable<IAsyncProcessor<T>> parallelProcessors
) : BaseProcessorRunnerDecorator<T>(asyncProcessorRunner)
{
    private IEnumerable<IAsyncProcessor<T>> _parallelProcessors = parallelProcessors;

    protected override async Task RunProcessorsAsync(T item)
    {
        var tasks = _parallelProcessors.Select(processor => processor.ProcessAsync(item));

        await Task.WhenAll(tasks);
    }

    protected override void ShuffleProcessors() => _parallelProcessors = _parallelProcessors.Shuffle();
}
