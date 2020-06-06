using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Processors
{
    /// <summary>
    ///     An async processor which processes an item asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the item to be processed.</typeparam>
    public interface IAsyncProcessor<in T>
    {
        /// <summary>
        ///     Process an item asynchronously.
        /// </summary>
        /// <param name="item">The item to be processed.</param>
        /// <returns>A <see cref="Task" /> to be awaited.</returns>
        Task ProcessAsync(T item);
    }
}