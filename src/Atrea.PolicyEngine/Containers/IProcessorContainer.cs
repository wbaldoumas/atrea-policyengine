using System.Collections.Generic;

namespace Atrea.PolicyEngine.Containers;

/// <summary>
///     Represents a container for processors.
/// </summary>
/// <typeparam name="T">The type of the processors.</typeparam>
public interface IProcessorContainer<T>
{
    /// <summary>
    ///     The processors.
    /// </summary>
    IReadOnlyCollection<T> Processors { get; }

    /// <summary>
    ///     Shuffle the order of the processors.
    /// </summary>
    void Shuffle();

    /// <summary>
    ///     Replace the processors with the given processors.
    /// </summary>
    /// <param name="processors">The processors to replace the current processors with.</param>
    void Replace(IReadOnlyCollection<T> processors);
}