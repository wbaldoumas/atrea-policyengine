namespace Atrea.PolicyEngine.Policies.Input;

/// <summary>
///     An <see cref="IInputPolicy{T}" /> which computes the boolean OR of two <see cref="IInputPolicy{T}" />s.
/// </summary>
/// <typeparam name="T">The type of the item being checked by this input policy.</typeparam>
public class Or<T> : IInputPolicy<T>
{
    private readonly IInputPolicy<T> _left;
    private readonly IInputPolicy<T> _right;

    /// <summary>
    ///     Construct an <see cref="Or{T}" /> input policy, which will compute the boolean OR of
    ///     the left and right component <see cref="IInputPolicy{T}" />s.
    /// </summary>
    /// <param name="left">The left <see cref="IInputPolicy{T}" /> to evaluate.</param>
    /// <param name="right">The right <see cref="IInputPolicy{T}" /> to evaluate.</param>
    public Or(IInputPolicy<T> left, IInputPolicy<T> right)
    {
        _left = left;
        _right = right;
    }

    public InputPolicyResult ShouldProcess(T item)
    {
        var leftResult = _left.ShouldProcess(item);
        var rightResult = _right.ShouldProcess(item);

        if (leftResult == InputPolicyResult.Reject && rightResult == InputPolicyResult.Reject)
        {
            return InputPolicyResult.Reject;
        }

        if (leftResult == InputPolicyResult.Accept || rightResult == InputPolicyResult.Accept)
        {
            return InputPolicyResult.Accept;
        }

        return InputPolicyResult.Continue;
    }
}