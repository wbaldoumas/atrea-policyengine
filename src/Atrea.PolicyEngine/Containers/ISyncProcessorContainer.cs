using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Containers;

/// <summary>
///     A container for synchronous processors.
/// </summary>
/// <typeparam name="T">The type of the items which the contained processors work with.</typeparam>
public interface ISyncProcessorContainer<T> : IProcessorContainer<IProcessor<T>>;