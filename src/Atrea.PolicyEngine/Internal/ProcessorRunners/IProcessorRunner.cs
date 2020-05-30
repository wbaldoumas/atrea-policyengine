namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    internal interface IProcessorRunner<in T>
    {
        void Process(T item);
    }
}