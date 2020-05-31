using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Policies.Output
{
    /// <summary>
    ///     An async output policy, which can asynchronously apply post-processing to an item processed by
    ///     the policy engine, perform cleanup actions, etc.
    /// </summary>
    /// <typeparam name="T">The type of the item to apply post-processing to.</typeparam>
    public interface IAsyncOutputPolicy<in T>
    {
        /// <summary>
        ///     Asynchronously apply post-processing to an item processed by the policy engine.
        /// </summary>
        /// <param name="item">The item to apply post-processing to.</param>
        /// <returns></returns>
        Task ApplyAsync(T item);
    }
}