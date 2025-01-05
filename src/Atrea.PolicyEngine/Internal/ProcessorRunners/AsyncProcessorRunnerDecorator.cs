using Atrea.PolicyEngine.Internal.Extensions;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal sealed class AsyncProcessorRunnerDecorator<T>(
    IAsyncProcessorRunner<T>? asyncProcessorRunner,
    IEnumerable<IAsyncProcessor<T>> asyncProcessors
) : BaseProcessorRunnerDecorator<T>(asyncProcessorRunner)
{
    private IEnumerable<IAsyncProcessor<T>> _asyncProcessors = asyncProcessors;

    protected override async Task RunProcessorsAsync(T item)
    {
        foreach (var asyncProcessor in _asyncProcessors)
        {
            await asyncProcessor.ProcessAsync(item);
        }
    }

    protected override void ShuffleProcessors() => _asyncProcessors = _asyncProcessors.Shuffle();
}
