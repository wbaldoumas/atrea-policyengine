using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;

[
    assembly:
    InternalsVisibleTo("Atrea.PolicyEngine.Tests"),
    InternalsVisibleTo("DynamicProxyGenAssembly2")
]

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal interface IAsyncInputPolicyRunner<in T>
    {
        Task<InputPolicyResult> ShouldProcessAsync(T item);
    }
}