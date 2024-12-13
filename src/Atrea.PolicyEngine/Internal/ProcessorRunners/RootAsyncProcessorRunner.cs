using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal class RootAsyncProcessorRunner<T> : IAsyncProcessorRunner<T>
{
    public Task ProcessAsync(T item)
    {
        var task = new Task(() => { });

        task.RunSynchronously(TaskScheduler.Default);

        return task;
    }

    public void Shuffle()
    {
    }
}