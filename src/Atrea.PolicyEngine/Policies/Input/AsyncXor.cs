﻿using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Policies.Input;

/// <summary>
///     An <see cref="IAsyncInputPolicy{T}" /> which computes the boolean XOR of two <see cref="IAsyncInputPolicy{T}" />s.
/// </summary>
/// <typeparam name="T">The type of the item being checked by this input policy.</typeparam>
public class AsyncXor<T> : IAsyncInputPolicy<T>
{
    private readonly IAsyncInputPolicy<T> _left;
    private readonly IAsyncInputPolicy<T> _right;

    /// <summary>
    ///     Construct an <see cref="AsyncXor{T}" /> input policy, which will compute the boolean XOR of
    ///     the left and right component <see cref="IAsyncInputPolicy{T}" />s.
    /// </summary>
    /// <param name="left">The left <see cref="IAsyncInputPolicy{T}" /> to evaluate.</param>
    /// <param name="right">The right <see cref="IAsyncInputPolicy{T}" /> to evaluate.</param>
    public AsyncXor(IAsyncInputPolicy<T> left, IAsyncInputPolicy<T> right)
    {
            _left = left;
            _right = right;
        }

    /// <inheritdoc cref="IAsyncInputPolicy{T}.ShouldProcessAsync"/>
    public async Task<InputPolicyResult> ShouldProcessAsync(T item)
    {
            var leftResult = await _left.ShouldProcessAsync(item);
            var rightResult = await _right.ShouldProcessAsync(item);

            if (leftResult == rightResult)
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