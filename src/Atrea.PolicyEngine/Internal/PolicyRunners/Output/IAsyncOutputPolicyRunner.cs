using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output;

internal interface IAsyncOutputPolicyRunner<in T>
{
    Task ApplyAsync(T item);
}