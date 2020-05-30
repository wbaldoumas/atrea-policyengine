using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal interface IAsyncInputPolicyRunner<in T>
    {
        Task<InputPolicyResult> ShouldProcessAsync(T item);
    }
}