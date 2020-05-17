namespace Atrea.Policy.Engine.Policies.Output
{
    /// <summary>
    ///     An output policy is used to apply post-processing to an item processed by the <see cref="PolicyEngine{T}" />
    /// </summary>
    /// <typeparam name="T">The type of item handled by this output policy</typeparam>
    public interface IOutputPolicy<in T>
    {
        /// <summary>
        ///     Apply post-processing to a given item that has been processed by the <see cref="PolicyEngine{T}" />
        /// </summary>
        /// <param name="item">The item to apply post-processing to</param>
        void Apply(T item);
    }
}