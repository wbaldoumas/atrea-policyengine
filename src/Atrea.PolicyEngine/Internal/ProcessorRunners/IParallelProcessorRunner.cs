namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    internal interface IParallelProcessorRunner<in T> : IAsyncProcessorRunner<T> { }
}