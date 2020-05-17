using System.Threading.Tasks;

namespace Atrea.Policy.Engine.Processors
{
    /// <summary>
    ///     A processor which can process an item.
    /// </summary>
    /// <typeparam name="T">The type of item to process</typeparam>
    public abstract class Processor<T>
    {
        /// <summary>
        ///     Process the given item.
        /// </summary>
        /// <param name="item">The item to process</param>
        public abstract void Process(T item);

        /// <summary>
        ///     Process the item asynchronously. Override this virtual method within
        ///     concrete implementations.
        /// </summary>
        /// <param name="item">The item to process</param>
        /// <returns>A <see cref="Task" /> which can be awaited</returns>
        public virtual async Task ProcessAsync(T item)
        {
            await Task.Run(() => Process(item));
        }
    }
}