using System.Collections.Generic;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Builders
{
    public interface IInputPolicyAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithInputPolicies(
            IEnumerable<IInputPolicy<T>> inputPolicies
        );

        IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithAsyncInputPolicies(
            IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies
        );
    }

    public interface IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T> : IProcessorAsyncPolicyEngineBuilder<T>
    {
        IProcessorAsyncPolicyEngineBuilder<T> WithAsyncInputPolicies(
            IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies
        );
    }

    public interface IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> :
        IProcessorAsyncPolicyEngineBuilder<T>
    {
        IProcessorAsyncPolicyEngineBuilder<T> WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies);
    }

    public interface IProcessorAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithProcessors(IEnumerable<IProcessor<T>> processors);

        IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithAsyncProcessors(
            IEnumerable<IAsyncProcessor<T>> asyncProcessors
        );

        IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithParallelProcessors(
            IEnumerable<IAsyncProcessor<T>> parallelProcessors
        );
    }

    public interface IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithAsyncProcessors(
            IEnumerable<IAsyncProcessor<T>> asyncProcessors
        );

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithParallelProcessors(
            IEnumerable<IAsyncProcessor<T>> parallelProcessors
        );
    }

    public interface IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithProcessors(
            IEnumerable<IProcessor<T>> processors
        );

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithParallelProcessors(
            IEnumerable<IAsyncProcessor<T>> parallelProcessors
        );
    }

    public interface IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
        : IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithProcessors(
            IEnumerable<IProcessor<T>> processors
        );

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithAsyncProcessors(
            IEnumerable<IAsyncProcessor<T>> asyncProcessors
        );
    }

    public interface IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        IOutputPolicyAsyncPolicyEngineBuilder<T> WithParallelProcessors(
            IEnumerable<IAsyncProcessor<T>> parallelProcessors
        );
    }

    public interface IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        IOutputPolicyAsyncPolicyEngineBuilder<T> WithAsyncProcessors(IEnumerable<IAsyncProcessor<T>> asyncProcessors);
    }

    public interface IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        IOutputPolicyAsyncPolicyEngineBuilder<T> WithProcessors(IEnumerable<IProcessor<T>> processors);
    }

    public interface IOutputPolicyAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        IWithOutputPoliciesAsyncPolicyEngineBuilder<T> WithOutputPolicies(IEnumerable<IOutputPolicy<T>> outputPolicies);

        IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T> WithAsyncOutputPolicies(
            IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies
        );

        IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithParallelOutputPolicies(
            IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies
        );
    }

    public interface IWithOutputPoliciesAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> WithAsyncOutputPolicies(
            IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies
        );

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithParallelOutputPolicies(
            IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies
        );
    }

    public interface IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> WithOutputPolicies(
            IEnumerable<IOutputPolicy<T>> outputPolicies
        );

        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithParallelOutputPolicies(
            IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies
        );
    }

    public interface IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithOutputPolicies(
            IEnumerable<IOutputPolicy<T>> outputPolicies
        );

        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithAsyncOutputPolicies(
            IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies
        );
    }

    public interface IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        IAsyncPolicyEngineBuilder<T> WithParallelOutputPolicies(
            IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies
        );
    }

    public interface
        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        IAsyncPolicyEngineBuilder<T> WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies);
    }

    public interface IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> :
        IAsyncPolicyEngineBuilder<T>
    {
        IAsyncPolicyEngineBuilder<T> WithOutputPolicies(IEnumerable<IOutputPolicy<T>> outputPolicies);
    }

    public interface IAsyncPolicyEngineBuilder<in T>
    {
        IAsyncPolicyEngine<T> Build();
    }
}