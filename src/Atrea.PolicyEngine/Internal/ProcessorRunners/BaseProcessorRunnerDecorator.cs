using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners;

internal abstract class BaseProcessorRunnerDecorator<T> : IAsyncProcessorRunner<T>
{
    private readonly IAsyncProcessorRunner<T>? _asyncProcessorRunner;

    private protected BaseProcessorRunnerDecorator(IAsyncProcessorRunner<T>? asyncProcessorRunner) =>
        _asyncProcessorRunner = asyncProcessorRunner;

    public async Task ProcessAsync(T item)
    {
        if (_asyncProcessorRunner is not null)
        {
            await _asyncProcessorRunner.ProcessAsync(item);
        }

        await RunProcessorsAsync(item);
    }

    public virtual void Shuffle()
    {
        _asyncProcessorRunner?.Shuffle();
        ShuffleProcessors();
    }

    protected abstract Task RunProcessorsAsync(T item);

    protected abstract void ShuffleProcessors();
}
