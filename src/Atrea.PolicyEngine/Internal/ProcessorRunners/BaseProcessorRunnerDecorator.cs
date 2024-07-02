using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal abstract class BaseProcessorRunnerDecorator<T> : IAsyncProcessorRunner<T>
{
    private readonly IAsyncProcessorRunner<T> _asyncProcessorRunner;

    private protected BaseProcessorRunnerDecorator(IAsyncProcessorRunner<T> asyncProcessorRunner) =>
        _asyncProcessorRunner = asyncProcessorRunner;

    public async Task ProcessAsync(T item)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        // This may be null if nullable reference types aren't enabled in dependent project.
        if (!(_asyncProcessorRunner is null))
        {
            await _asyncProcessorRunner.ProcessAsync(item);
        }

        await RunProcessorsAsync(item);
    }

    protected abstract Task RunProcessorsAsync(T item);
}