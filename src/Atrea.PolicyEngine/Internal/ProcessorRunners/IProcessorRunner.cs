using Atrea.PolicyEngine.Containers;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal interface IProcessorRunner<T> : ISyncProcessorContainer<T>
{
    void Process(T item);
}
