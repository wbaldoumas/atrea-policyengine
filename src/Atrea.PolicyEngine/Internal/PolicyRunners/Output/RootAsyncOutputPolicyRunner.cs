using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output;

internal sealed class RootAsyncOutputPolicyRunner<T> : IAsyncOutputPolicyRunner<T>
{
    public Task ApplyAsync(T item)
    {
        var task = new Task(() => { });

        task.RunSynchronously(TaskScheduler.Default);

        return task;
    }
}