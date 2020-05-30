namespace Atrea.PolicyEngine.Policies.Output
{
    /// <summary>
    ///     An output policy, which can apply post-processing to an item processed by the policy engine,
    ///     perform cleanup actions, etc.
    /// </summary>
    /// <typeparam name="T">The type of the item to apply post-processing to.</typeparam>
    public interface IOutputPolicy<in T>
    {
        /// <summary>
        ///     Apply post-processing to an item processed by the policy engine.
        /// </summary>
        /// <param name="item">The item to apply post-processing to.</param>
        void Apply(T item);
    }
}