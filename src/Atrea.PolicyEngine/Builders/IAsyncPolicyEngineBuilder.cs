using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Builders
{
    public interface IInputPolicyAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous input policies.
        /// </summary>
        /// <param name="inputPolicies">The synchronous input policies to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithInputPoliciesProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithInputPolicies(
            params IInputPolicy<T>[] inputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous input policies.
        /// </summary>
        /// <param name="asyncInputPolicies">
        ///     The asynchronous input policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithAsyncInputPolicies(
            params IAsyncInputPolicy<T>[] asyncInputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel input policies.
        /// </summary>
        /// <param name="parallelInputPolicies">
        ///     The parallel input policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithParallelInputPolicies(
            params IAsyncInputPolicy<T>[] parallelInputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> without input policies.
        /// </summary>
        /// <returns>
        ///     <see cref="IProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IProcessorAsyncPolicyEngineBuilder<T> WithoutInputPolicies();
    }

    public interface IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T> : IProcessorAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous input policies.
        /// </summary>
        /// <param name="asyncInputPolicies">
        ///     The asynchronous input policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithSynchronousAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithAsyncInputPolicies(
            params IAsyncInputPolicy<T>[] asyncInputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel input policies.
        /// </summary>
        /// <param name="parallelInputPolicies">
        ///     The parallel input policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithParallelInputPolicies(
            params IAsyncInputPolicy<T>[] parallelInputPolicies
        );
    }


    public interface IWithSynchronousAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> :
        IProcessorAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel input policies.
        /// </summary>
        /// <param name="parallelInputPolicies">
        ///     The parallel input policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IProcessorAsyncPolicyEngineBuilder<T> WithParallelInputPolicies(
            params IAsyncInputPolicy<T>[] parallelInputPolicies
        );
    }

    public interface IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> :
        IProcessorAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous input policies.
        /// </summary>
        /// <param name="inputPolicies">The synchronous input policies to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithSynchronousAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithInputPolicies(
            params IInputPolicy<T>[] inputPolicies);


        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel input policies.
        /// </summary>
        /// <param name="parallelInputPolicies">
        ///     The parallel input policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithParallelInputPolicies(
            params IAsyncInputPolicy<T>[] parallelInputPolicies
        );
    }

    public interface IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T> :
        IProcessorAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous input policies.
        /// </summary>
        /// <param name="inputPolicies">The synchronous input policies to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithInputPolicies(
            params IInputPolicy<T>[] inputPolicies);

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous input policies.
        /// </summary>
        /// <param name="asyncInputPolicies">
        ///     The asynchronous input policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> WithAsyncInputPolicies(
            params IAsyncInputPolicy<T>[] asyncInputPolicies
        );
    }

    public interface IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
        : IProcessorAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous input policies.
        /// </summary>
        /// <param name="asyncInputPolicies">
        ///     The asynchronous input policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IProcessorAsyncPolicyEngineBuilder<T> WithAsyncInputPolicies(
            params IAsyncInputPolicy<T>[] asyncInputPolicies
        );
    }

    public interface
        IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> : IProcessorAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous input policies.
        /// </summary>
        /// <param name="inputPolicies">The synchronous input policies to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IProcessorAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IProcessorAsyncPolicyEngineBuilder<T> WithInputPolicies(params IInputPolicy<T>[] inputPolicies);
    }

    public interface IProcessorAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous processors.
        /// </summary>
        /// <param name="processors">The synchronous processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithProcessors(params IProcessor<T>[] processors);

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous processors.
        /// </summary>
        /// <param name="asyncProcessors">The asynchronous processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithAsyncProcessors(
            params IAsyncProcessor<T>[] asyncProcessors
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel processors.
        /// </summary>
        /// <param name="parallelProcessors">The parallel processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithParallelProcessors(
            params IAsyncProcessor<T>[] parallelProcessors
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> without processors.
        /// </summary>
        /// <returns>
        ///     <see cref="IOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IOutputPolicyAsyncPolicyEngineBuilder<T> WithoutProcessors();
    }

    public interface IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous processors.
        /// </summary>
        /// <param name="asyncProcessors">The asynchronous processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithAsyncProcessors(
            params IAsyncProcessor<T>[] asyncProcessors
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel processors.
        /// </summary>
        /// <param name="parallelProcessors">The parallel processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithParallelProcessors(
            params IAsyncProcessor<T>[] parallelProcessors
        );
    }

    public interface IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous processors.
        /// </summary>
        /// <param name="processors">The synchronous processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithProcessors(
            params IProcessor<T>[] processors
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel processors.
        /// </summary>
        /// <param name="parallelProcessors">The parallel processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithParallelProcessors(
            params IAsyncProcessor<T>[] parallelProcessors
        );
    }

    public interface IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
        : IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous processors.
        /// </summary>
        /// <param name="processors">The synchronous processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithProcessors(
            params IProcessor<T>[] processors
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous processors.
        /// </summary>
        /// <param name="asyncProcessors">The asynchronous processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> WithAsyncProcessors(
            params IAsyncProcessor<T>[] asyncProcessors
        );
    }

    public interface IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel processors.
        /// </summary>
        /// <param name="parallelProcessors">The parallel processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IOutputPolicyAsyncPolicyEngineBuilder<T> WithParallelProcessors(
            params IAsyncProcessor<T>[] parallelProcessors
        );
    }

    public interface IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous processors.
        /// </summary>
        /// <param name="asyncProcessors">The asynchronous processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IOutputPolicyAsyncPolicyEngineBuilder<T> WithAsyncProcessors(params IAsyncProcessor<T>[] asyncProcessors);
    }

    public interface IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> :
        IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous processors.
        /// </summary>
        /// <param name="processors">The synchronous processors to configure the <see cref="IAsyncPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IOutputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IOutputPolicyAsyncPolicyEngineBuilder<T> WithProcessors(params IProcessor<T>[] processors);
    }

    public interface IOutputPolicyAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous output policies.
        /// </summary>
        /// <param name="outputPolicies">
        ///     The synchronous output policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithOutputPoliciesAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithOutputPoliciesAsyncPolicyEngineBuilder<T> WithOutputPolicies(params IOutputPolicy<T>[] outputPolicies);

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous output policies.
        /// </summary>
        /// <param name="asyncOutputPolicies">
        ///     The asynchronous output policies to configure the
        ///     <see cref="IAsyncPolicyEngine{T}" /> with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T> WithAsyncOutputPolicies(
            params IAsyncOutputPolicy<T>[] asyncOutputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel output policies.
        /// </summary>
        /// <param name="parallelOutputPolicies">
        ///     The parallel output policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithParallelOutputPoliciesAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithParallelOutputPolicies(
            params IAsyncOutputPolicy<T>[] parallelOutputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> without output policies.
        /// </summary>
        /// <returns>
        ///     <see cref="IAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IAsyncPolicyEngineBuilder<T> WithoutOutputPolicies();
    }

    public interface IWithOutputPoliciesAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous output policies.
        /// </summary>
        /// <param name="asyncOutputPolicies">
        ///     The asynchronous output policies to configure the
        ///     <see cref="IAsyncPolicyEngine{T}" /> with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder{T}" />
        /// </returns>
        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> WithAsyncOutputPolicies(
            params IAsyncOutputPolicy<T>[] asyncOutputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel output policies.
        /// </summary>
        /// <param name="parallelOutputPolicies">
        ///     The parallel output policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithParallelOutputPolicies(
            params IAsyncOutputPolicy<T>[] parallelOutputPolicies
        );
    }

    public interface IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous output policies.
        /// </summary>
        /// <param name="outputPolicies">
        ///     The synchronous output policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder{T}" />
        /// </returns>
        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> WithOutputPolicies(
            params IOutputPolicy<T>[] outputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel output policies.
        /// </summary>
        /// <param name="parallelOutputPolicies">
        ///     The parallel output policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithParallelOutputPolicies(
            params IAsyncOutputPolicy<T>[] parallelOutputPolicies
        );
    }

    public interface IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous output policies.
        /// </summary>
        /// <param name="outputPolicies">
        ///     The synchronous output policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithOutputPolicies(
            params IOutputPolicy<T>[] outputPolicies
        );

        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous output policies.
        /// </summary>
        /// <param name="asyncOutputPolicies">
        ///     The asynchronous output policies to configure the
        ///     <see cref="IAsyncPolicyEngine{T}" /> with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> WithAsyncOutputPolicies(
            params IAsyncOutputPolicy<T>[] asyncOutputPolicies
        );
    }

    public interface IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> : IAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given parallel output policies.
        /// </summary>
        /// <param name="parallelOutputPolicies">
        ///     The parallel output policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IAsyncPolicyEngineBuilder<T> WithParallelOutputPolicies(
            params IAsyncOutputPolicy<T>[] parallelOutputPolicies
        );
    }

    public interface IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> :
        IAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given asynchronous output policies.
        /// </summary>
        /// <param name="asyncOutputPolicies">
        ///     The asynchronous output policies to configure the
        ///     <see cref="IAsyncPolicyEngine{T}" /> with.
        /// </param>
        /// <returns>
        ///     <see cref="IAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IAsyncPolicyEngineBuilder<T> WithAsyncOutputPolicies(params IAsyncOutputPolicy<T>[] asyncOutputPolicies);
    }

    public interface IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T> :
        IAsyncPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configure the <see cref="IAsyncPolicyEngine{T}" /> with the given synchronous output policies.
        /// </summary>
        /// <param name="outputPolicies">
        ///     The synchronous output policies to configure the <see cref="IAsyncPolicyEngine{T}" />
        ///     with.
        /// </param>
        /// <returns>
        ///     <see cref="IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        IAsyncPolicyEngineBuilder<T> WithOutputPolicies(params IOutputPolicy<T>[] outputPolicies);
    }

    public interface IAsyncPolicyEngineBuilder<in T>
    {
        /// <summary>
        ///     Builds the configured <see cref="IAsyncPolicyEngine{T}" />.
        /// </summary>
        /// <returns>A configured <see cref="IAsyncPolicyEngine{T}" />.</returns>
        IAsyncPolicyEngine<T> Build();
    }
}