using Atrea.PolicyEngine.Policies.Input;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Atrea.PolicyEngine.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input;

internal interface IAsyncInputPolicyRunner<in T>
{
    Task<InputPolicyResult> ShouldProcessAsync(T item);
}