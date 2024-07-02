using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal class AsyncProcessorRunnerDecorator<T> : BaseProcessorRunnerDecorator<T>
{
    private readonly IEnumerable<IAsyncProcessor<T>> _asyncProcessors;

    public AsyncProcessorRunnerDecorator(
        IAsyncProcessorRunner<T> asyncProcessorRunner,
        IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        : base(
            asyncProcessorRunner) =>
        _asyncProcessors = asyncProcessors;

    protected override async Task RunProcessorsAsync(T item)
    {
        foreach (var asyncProcessor in _asyncProcessors)
        {
            await asyncProcessor.ProcessAsync(item);
        }
    }
}