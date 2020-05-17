using System.Threading.Tasks;

namespace Atrea.Policy.Engine
{
    /// <summary>
    ///     A policy engine, which will check if an item should be processed with its input policies,
    ///     process the item with its processors, then apply post-processing with its output policies.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPolicyEngine<in T>
    {
        /// <summary>
        ///     Process the item, running each processor in parallel.
        /// </summary>
        /// <param name="item">The item to process</param>
        /// <returns>A <see cref="Task" /> which can be awaited</returns>
        Task ProcessParallel(T item);
    }
}