using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine
{
    public interface IPolicyEngine<in T> : IProcessor<T> { }
}