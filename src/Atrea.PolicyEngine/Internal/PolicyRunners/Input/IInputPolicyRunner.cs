using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Input
{
    internal interface IInputPolicyRunner<in T>
    {
        InputPolicyResult ShouldProcess(T item);
    }
}