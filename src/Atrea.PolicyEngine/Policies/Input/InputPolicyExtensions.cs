namespace Atrea.PolicyEngine.Policies.Input
{
    public static class InputPolicyExtensions
    {
        public static IInputPolicy<T> And<T>(this IInputPolicy<T> source, IInputPolicy<T> other) =>
            new And<T>(source, other);

        public static IAsyncInputPolicy<T> And<T>(this IAsyncInputPolicy<T> source, IAsyncInputPolicy<T> other) =>
            new AsyncAnd<T>(source, other);

        public static IInputPolicy<T> Or<T>(this IInputPolicy<T> source, IInputPolicy<T> other) =>
            new Or<T>(source, other);

        public static IAsyncInputPolicy<T> Or<T>(this IAsyncInputPolicy<T> source, IAsyncInputPolicy<T> other) =>
            new AsyncOr<T>(source, other);

        public static IInputPolicy<T> Xor<T>(this IInputPolicy<T> source, IInputPolicy<T> other) =>
            new Xor<T>(source, other);

        public static IAsyncInputPolicy<T> Xor<T>(this IAsyncInputPolicy<T> source, IAsyncInputPolicy<T> other) =>
            new AsyncXor<T>(source, other);
    }
}