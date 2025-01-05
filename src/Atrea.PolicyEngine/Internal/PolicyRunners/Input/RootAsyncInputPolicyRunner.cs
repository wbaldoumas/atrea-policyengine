using Atrea.PolicyEngine.Policies.Input;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input;

internal sealed class RootAsyncInputPolicyRunner<T> : IAsyncInputPolicyRunner<T>
{
    public Task<InputPolicyResult> ShouldProcessAsync(T item)
    {
        var task = new Task<InputPolicyResult>(() => InputPolicyResult.Continue);

        task.RunSynchronously(TaskScheduler.Default);

        return task;
    }
}