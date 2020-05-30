namespace Atrea.PolicyEngine.Policies.Output
{
    public interface IOutputPolicy<in T>
    {
        void Apply(T item);
    }
}