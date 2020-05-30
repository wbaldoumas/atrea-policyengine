namespace Atrea.PolicyEngine.Policies.Input
{
    /// <summary>
    ///     A result of an <see cref="IInputPolicy{T}"/>, to be used by the <see cref="IPolicyEngine{T}"/>
    ///     and <see cref="IAsyncPolicyEngine{T}"/>.
    /// </summary>
    public enum InputPolicyResult
    {
        /// <summary>
        ///     Accept the item as input and skip remaining input policies.
        /// </summary>
        Accept,

        /// <summary>
        ///     Reject the item as input - skip remaining input policies, processors, and output policies.
        /// </summary>
        Reject,

        /// <summary>
        ///     Accept the item for this given <see cref="IInputPolicy{T}"/> and continue evaluating remaining
        ///     input policies, or being processing if this is the result of the last input policy run.
        /// </summary>
        Continue
    }
}