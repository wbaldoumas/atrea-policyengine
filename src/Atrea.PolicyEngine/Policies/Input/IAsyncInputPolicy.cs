using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Policies.Input
{
    public interface IAsyncInputPolicy<in T>
    {
        Task<InputPolicyResult> ShouldProcessAsync(T item);
    }
}