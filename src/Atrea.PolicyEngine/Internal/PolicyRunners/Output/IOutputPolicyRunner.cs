namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output;

internal interface IOutputPolicyRunner<in T>
{
    void Apply(T item);
}