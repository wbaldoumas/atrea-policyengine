using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Builders
{
    public interface IInputPolicyEngineBuilder<T> : IPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configures the <see cref="IPolicyEngine{T}" /> with the given input policies.
        /// </summary>
        /// <param name="inputPolicies">The input policies to configure the <see cref="IPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IProcessorPolicyEngineBuilder{T}" />
        /// </returns>
        IProcessorPolicyEngineBuilder<T> WithInputPolicies(params IInputPolicy<T>[] inputPolicies);

        /// <summary>
        ///     Configures the <see cref="IPolicyEngine{T}" /> without input policies.
        /// </summary>
        /// <returns>
        ///     <see cref="IProcessorPolicyEngineBuilder{T}" />
        /// </returns>
        IProcessorPolicyEngineBuilder<T> WithoutInputPolicies();
    }

    public interface IProcessorPolicyEngineBuilder<T> : IPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configures the <see cref="IPolicyEngine{T}" /> with the given processors.
        /// </summary>
        /// <param name="processors">The processors to configure the <see cref="IPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IOutputPolicyEngineBuilder{T}" />
        /// </returns>
        IOutputPolicyEngineBuilder<T> WithProcessors(params IProcessor<T>[] processors);

        /// <summary>
        ///     Configures the <see cref="IPolicyEngine{T}" /> without processors.
        /// </summary>
        /// <returns>
        ///     <see cref="IOutputPolicyEngineBuilder{T}" />
        /// </returns>
        IOutputPolicyEngineBuilder<T> WithoutProcessors();
    }

    public interface IOutputPolicyEngineBuilder<T> : IPolicyEngineBuilder<T>
    {
        /// <summary>
        ///     Configures the <see cref="IPolicyEngine{T}" /> with the given output policies.
        /// </summary>
        /// <param name="outputPolicies">The output policies to configure the <see cref="IPolicyEngine{T}" /> with.</param>
        /// <returns>
        ///     <see cref="IPolicyEngineBuilder{T}" />
        /// </returns>
        IPolicyEngineBuilder<T> WithOutputPolicies(params IOutputPolicy<T>[] outputPolicies);

        /// <summary>
        ///     Configures the <see cref="IPolicyEngine{T}" /> without output policies.
        /// </summary>
        /// <returns>
        ///     <see cref="IPolicyEngineBuilder{T}" />
        /// </returns>
        IPolicyEngineBuilder<T> WithoutOutputPolicies();
    }

    public interface IPolicyEngineBuilder<in T>
    {
        /// <summary>
        ///     Builds the configured <see cref="IPolicyEngine{T}" />.
        /// </summary>
        /// <returns>A configured <see cref="IPolicyEngine{T}" />.</returns>
        IPolicyEngine<T> Build();
    }
}