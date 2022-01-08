using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Policies.Input
{
    /// <summary>
    ///     An <see cref="IAsyncInputPolicy{T}" /> which computes the boolean NOT of a given
    ///     <see cref="IAsyncInputPolicy{T}" />.
    ///     If a given input policy resolves to <see cref="InputPolicyResult.Continue" /> or
    ///     <see cref="InputPolicyResult.Accept" />
    ///     then the item is rejected and <see cref="InputPolicyResult.Reject" /> is returned, otherwise
    ///     <see cref="InputPolicyResult.Continue" />
    ///     is returned.
    /// </summary>
    /// <typeparam name="T">The type of the item being checked by this input policy.</typeparam>
    public class AsyncNot<T> : IAsyncInputPolicy<T>
    {
        private readonly IAsyncInputPolicy<T> _inputPolicy;

        /// <summary>
        ///     Construct an <see cref="IAsyncInputPolicy{T}" /> which computes the boolean NOT of the given
        ///     <see cref="IAsyncInputPolicy{T}" />.
        ///     If the given input policy resolves to <see cref="InputPolicyResult.Continue" /> or
        ///     <see cref="InputPolicyResult.Accept" />
        ///     then the item is rejected and <see cref="InputPolicyResult.Reject" /> is returned, otherwise
        ///     <see cref="InputPolicyResult.Continue" />
        ///     is returned.
        /// </summary>
        /// <param name="inputPolicy">The <see cref="IAsyncInputPolicy{T}" /> to compute the boolean NOT of.</param>
        public AsyncNot(IAsyncInputPolicy<T> inputPolicy) => _inputPolicy = inputPolicy;

        /// <inheritdoc cref="IAsyncInputPolicy{T}.ShouldProcessAsync"/>
        public async Task<InputPolicyResult> ShouldProcessAsync(T item) =>
            await _inputPolicy.ShouldProcessAsync(item) == InputPolicyResult.Reject
                ? InputPolicyResult.Continue
                : InputPolicyResult.Reject;
    }
}