using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine
{
    /// <summary>
    ///     An async policy engine which will check if an item should be processed with its input policies,
    ///     process the item using its processors, then apply any post-processing to the item using its
    ///     output policies. Note that this engine can be configured with non-async and async input policies,
    ///     non-async, async, and parallel processors, and non-async, async, and parallel output policies.
    ///     See <see cref="AsyncPolicyEngineBuilder{T}" /> for configuration of this async policy engine.
    /// </summary>
    /// <typeparam name="T">The type of the item to be processed.</typeparam>
    public interface IAsyncPolicyEngine<in T> : IAsyncProcessor<T>
    {
        /// <summary>
        ///     Process items.
        /// </summary>
        /// <param name="items">The items to be processed.</param>
        Task ProcessAsync(IEnumerable<T> items);

        /// <summary>
        ///     Process items.
        /// </summary>
        /// <param name="items">The items to be processed.</param>
        Task ProcessParallel(IEnumerable<T> items);
    }
}