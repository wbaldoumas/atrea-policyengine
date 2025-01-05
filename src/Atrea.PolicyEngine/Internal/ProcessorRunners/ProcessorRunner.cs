using Atrea.PolicyEngine.Internal.Extensions;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;
using System.Linq;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal sealed class ProcessorRunner<T>(IReadOnlyCollection<IProcessor<T>> processors) : IProcessorRunner<T>
{
    public IReadOnlyCollection<IProcessor<T>> Processors { get; private set; } = processors;

    public void Process(T item)
    {
        foreach (var processor in Processors)
        {
            processor.Process(item);
        }
    }

    public void Shuffle() => Processors = Processors.Shuffle().ToList();

    public void Replace(IReadOnlyCollection<IProcessor<T>> processors) => Processors = processors;
}
