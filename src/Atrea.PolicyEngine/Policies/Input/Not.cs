namespace Atrea.PolicyEngine.Policies.Input;

/// <summary>
///     An <see cref="IInputPolicy{T}" /> which computes the boolean NOT of a given <see cref="IInputPolicy{T}" />.
///     If a given input policy resolves to <see cref="InputPolicyResult.Continue" /> or
///     <see cref="InputPolicyResult.Accept" />
///     then the item is rejected and <see cref="InputPolicyResult.Reject" /> is returned, otherwise
///     <see cref="InputPolicyResult.Continue" />
///     is returned.
/// </summary>
/// <typeparam name="T">The type of the item being checked by this input policy.</typeparam>
public class Not<T> : IInputPolicy<T>
{
    private readonly IInputPolicy<T> _inputPolicy;

    /// <summary>
    ///     Construct an <see cref="IInputPolicy{T}" /> which computes the boolean NOT of the given
    ///     <see cref="IInputPolicy{T}" />.
    ///     If the given input policy resolves to <see cref="InputPolicyResult.Continue" /> or
    ///     <see cref="InputPolicyResult.Accept" />
    ///     then the item is rejected and <see cref="InputPolicyResult.Reject" /> is returned, otherwise
    ///     <see cref="InputPolicyResult.Continue" />
    ///     is returned.
    /// </summary>
    /// <param name="inputPolicy">The <see cref="IInputPolicy{T}" /> to compute the boolean NOT of.</param>
    public Not(IInputPolicy<T> inputPolicy) => _inputPolicy = inputPolicy;

    public InputPolicyResult ShouldProcess(T item) => _inputPolicy.ShouldProcess(item) == InputPolicyResult.Reject
        ? InputPolicyResult.Continue
        : InputPolicyResult.Reject;
}