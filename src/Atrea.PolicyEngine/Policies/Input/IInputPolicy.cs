namespace Atrea.PolicyEngine.Policies.Input
{
    public interface IInputPolicy<in T>
    {
        InputPolicyResult ShouldProcess(T item);
    }
}