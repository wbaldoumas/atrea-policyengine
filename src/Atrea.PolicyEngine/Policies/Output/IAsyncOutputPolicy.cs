using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Policies.Output
{
    public interface IAsyncOutputPolicy<in T>
    {
        Task ApplyAsync(T item);
    }
}