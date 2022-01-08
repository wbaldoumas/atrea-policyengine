using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;

namespace Atrea.PolicyEngine
{
    /// <summary>
    ///     A policy engine which will check if an item should be processed with its input policies,
    ///     process the item using its processors, then apply any post-processing to the item using its
    ///     output policies.
    ///     See <see cref="PolicyEngineBuilder{T}" /> for configuration of this policy engine.
    /// </summary>
    /// <typeparam name="T">The type of the item to be processed.</typeparam>
    public interface IPolicyEngine<in T> : IProcessor<T>
    {
        /// <summary>
        ///     Process items.
        /// </summary>
        /// <param name="items">The items to be processed.</param>
        void Process(IEnumerable<T> items);
    }
}