using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Processors
{
    public interface IAsyncProcessor<in T>
    {
        Task ProcessAsync(T item);
    }
}