using Atrea.PolicyEngine.Internal.Extensions;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal class ProcessorRunner<T> : IProcessorRunner<T>
{
    private IEnumerable<IProcessor<T>> _processors;

    public ProcessorRunner(IEnumerable<IProcessor<T>> processors) => _processors = processors;

    public void Process(T item)
    {
        foreach (var processor in _processors)
        {
            processor.Process(item);
        }
    }

    public void Shuffle() => _processors = _processors.Shuffle();
}