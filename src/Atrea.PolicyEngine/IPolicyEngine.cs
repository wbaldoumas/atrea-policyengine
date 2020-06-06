using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine
{
    /// <summary>
    ///     A policy engine which will check if an item should be processed with its input policies,
    ///     process the item using its processors, then apply any post-processing to the item using its
    ///     output policies.
    ///     See <see cref="PolicyEngineBuilder{T}" /> for configuration of this policy engine.
    /// </summary>
    /// <typeparam name="T">The type of the item to be processed.</typeparam>
    public interface IPolicyEngine<in T> : IProcessor<T> { }
}