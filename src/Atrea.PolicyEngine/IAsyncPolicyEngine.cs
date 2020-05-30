using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine
{
    public interface IAsyncPolicyEngine<in T> : IAsyncProcessor<T> { }
}