using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Policies.Input
{
    /// <summary>
    ///     An async input policy, which can take in an item and return an <see cref="InputPolicyResult"/> to indicate
    ///     whether the item should be processed or not by the policy engine.
    /// </summary>
    /// <typeparam name="T">The type of the item to be checked by the <see cref="IAsyncInputPolicy{T}"/>.</typeparam>
    public interface IAsyncInputPolicy<in T>
    {
        /// <summary>
        ///     Asynchronously determine whether the item should be processed by the policy engine.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>A <see cref="Task{InputPolicyResult}"/> to await, whose result is an <see cref="InputPolicyResult"/>.</returns>
        Task<InputPolicyResult> ShouldProcessAsync(T item);
    }
}