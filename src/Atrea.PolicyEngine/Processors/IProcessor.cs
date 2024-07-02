namespace Atrea.PolicyEngine.Processors;

/// <summary>
///     A processor which processes an item.
/// </summary>
/// <typeparam name="T">The type of the item to be processed.</typeparam>
public interface IProcessor<in T>
{
    /// <summary>
    ///     Process an item.
    /// </summary>
    /// <param name="item">The item to be processed.</param>
    void Process(T item);
}