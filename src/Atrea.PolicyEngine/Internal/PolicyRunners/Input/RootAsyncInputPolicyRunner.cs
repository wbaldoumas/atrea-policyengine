using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal class RootAsyncInputPolicyRunner<T> : IAsyncInputPolicyRunner<T>
    {
        public Task<InputPolicyResult> ShouldProcessAsync(T item)
        {
            var task = new Task<InputPolicyResult>(() => InputPolicyResult.Continue);

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }
    }
}