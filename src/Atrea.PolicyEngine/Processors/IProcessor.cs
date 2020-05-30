namespace Atrea.PolicyEngine.Processors
{
    public interface IProcessor<in T>
    {
        void Process(T item);
    }
}