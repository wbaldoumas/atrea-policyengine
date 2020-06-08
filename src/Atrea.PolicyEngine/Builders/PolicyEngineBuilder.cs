using System.Collections.Generic;
using Atrea.PolicyEngine.Internal.Engines;
using Atrea.PolicyEngine.Internal.PolicyRunners.Input;
using Atrea.PolicyEngine.Internal.PolicyRunners.Output;
using Atrea.PolicyEngine.Internal.ProcessorRunners;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Builders
{
    /// <summary>
    ///     A builder class for configuring and building an <see cref="IPolicyEngine{T}" />.
    /// </summary>
    /// <typeparam name="T">The type of the item to be processed by the <see cref="IPolicyEngine{T}" /></typeparam>
    public class PolicyEngineBuilder<T> :
        IInputPolicyEngineBuilder<T>,
        IProcessorPolicyEngineBuilder<T>,
        IOutputPolicyEngineBuilder<T>
    {
        private IEnumerable<IInputPolicy<T>> _inputPolicies = new List<IInputPolicy<T>>();
        private IEnumerable<IOutputPolicy<T>> _outputPolicies = new List<IOutputPolicy<T>>();
        private IEnumerable<IProcessor<T>> _processors = new List<IProcessor<T>>();

        public IProcessorPolicyEngineBuilder<T> WithInputPolicies(params IInputPolicy<T>[] inputPolicies)
        {
            _inputPolicies = inputPolicies;

            return this;
        }

        public IProcessorPolicyEngineBuilder<T> WithoutInputPolicies() => this;

        public IPolicyEngine<T> Build()
        {
            var policyEngine = new PolicyEngine<T>();

            policyEngine.SetInputPolicyRunner(new InputPolicyRunner<T>(_inputPolicies));
            policyEngine.SetProcessorRunner(new ProcessorRunner<T>(_processors));
            policyEngine.SetOutputPolicyRunner(new OutputPolicyRunner<T>(_outputPolicies));

            return policyEngine;
        }

        public IPolicyEngineBuilder<T> WithOutputPolicies(params IOutputPolicy<T>[] outputPolicies)
        {
            _outputPolicies = outputPolicies;

            return this;
        }

        public IPolicyEngineBuilder<T> WithoutOutputPolicies() => this;

        public IOutputPolicyEngineBuilder<T> WithProcessors(params IProcessor<T>[] processors)
        {
            _processors = processors;

            return this;
        }

        public IOutputPolicyEngineBuilder<T> WithoutProcessors() => this;

        /// <summary>
        ///     Begin configuring a <see cref="IPolicyEngine{T}" />.
        /// </summary>
        /// <returns>
        ///     <see cref="IInputPolicyEngineBuilder{T}" />
        /// </returns>
        public static IInputPolicyEngineBuilder<T> Configure() => new PolicyEngineBuilder<T>();
    }
}