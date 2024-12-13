using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal interface IAsyncProcessorRunner<in T>
{
    Task ProcessAsync(T item);

    void Shuffle();
}