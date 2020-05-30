namespace Atrea.PolicyEngine.Policies.Input
{
    /// <summary>
    ///     An input policy, which can take in an item and return an <see cref="InputPolicyResult"/> to indicate
    ///     whether the item should be processed or not by the policy engine.
    /// </summary>
    /// <typeparam name="T">The type of the item to be checked by the <see cref="IInputPolicy{T}"/>.</typeparam>
    public interface IInputPolicy<in T>
    {
        /// <summary>
        ///     Determine whether the item should be processed by the policy engine.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>An <see cref="InputPolicyResult"/> which indicates whether the item should be processed or not.</returns>
        InputPolicyResult ShouldProcess(T item);
    }
}