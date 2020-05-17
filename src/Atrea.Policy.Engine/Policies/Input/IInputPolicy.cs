namespace Atrea.Policy.Engine.Policies.Input
{
    /// <summary>
    ///     An input policy, which is used by the <see cref="PolicyEngine{T}" /> to determine whether
    ///     or not a given item should be processed.
    /// </summary>
    /// <typeparam name="T">The type of item handled by this input policy</typeparam>
    public interface IInputPolicy<in T>
    {
        /// <summary>
        ///     Checks whether an item should be processed by the <see cref="PolicyEngine{T}" /> or not:
        ///     A return value of <see cref="InputPolicyResult.Accept" /> indicates to skip subsequent input
        ///     policies and immediately begin processing the item.
        ///     A return value of <see cref="InputPolicyResult.Continue" /> indicates to proceed to the next
        ///     <see cref="IInputPolicy{T}" /> if any remain, or to begin processing the item if this was the
        ///     last input policy evaluated.
        ///     A return value of <see cref="InputPolicyResult.Reject" /> indicates that the given item should
        ///     not be processed by the <see cref="PolicyEngine{T}" />
        /// </summary>
        /// <param name="item">The item to check</param>
        /// <returns>An <see cref="InputPolicyResult" /></returns>
        InputPolicyResult ShouldProcess(T item);
    }
}