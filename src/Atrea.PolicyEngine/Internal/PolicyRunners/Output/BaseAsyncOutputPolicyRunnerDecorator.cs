using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.PolicyRunners.Output;

internal abstract class BaseAsyncOutputPolicyRunnerDecorator<T> : IAsyncOutputPolicyRunner<T>
{
    private readonly IAsyncOutputPolicyRunner<T> _asyncOutputPolicyRunner;

    protected BaseAsyncOutputPolicyRunnerDecorator(IAsyncOutputPolicyRunner<T> asyncOutputPolicyRunner) =>
        _asyncOutputPolicyRunner = asyncOutputPolicyRunner;

    public async Task ApplyAsync(T item)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        // This may be null if nullable reference types aren't enabled in dependent project.
        if (_asyncOutputPolicyRunner is not null)
        {
            await _asyncOutputPolicyRunner.ApplyAsync(item);
        }

        await ApplyOutputPoliciesAsync(item);
    }

    protected abstract Task ApplyOutputPoliciesAsync(T item);
}