using Atrea.PolicyEngine.Internal.Extensions;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal sealed class SynchronousProcessorRunner<T>(
    IAsyncProcessorRunner<T>? asyncProcessorRunner,
    IEnumerable<IProcessor<T>> processors
) : BaseProcessorRunnerDecorator<T>(asyncProcessorRunner)
{
    private IEnumerable<IProcessor<T>> _processors = processors;

    protected override Task RunProcessorsAsync(T item)
    {
        var task = new Task(() =>
        {
            foreach (var processor in _processors)
            {
                processor.Process(item);
            }
        });

        task.RunSynchronously(TaskScheduler.Default);

        return task;
    }

    protected override void ShuffleProcessors() => _processors = _processors.Shuffle();
}
