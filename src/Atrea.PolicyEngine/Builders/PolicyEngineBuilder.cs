using Atrea.PolicyEngine.Internal.Engines;
using Atrea.PolicyEngine.Internal.PolicyRunners.Input;
using Atrea.PolicyEngine.Internal.PolicyRunners.Output;
using Atrea.PolicyEngine.Internal.ProcessorRunners;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;

namespace Atrea.PolicyEngine.Builders
{
    public class PolicyEngineBuilder<T> :
        IInputPolicyEngineBuilder<T>,
        IProcessorPolicyEngineBuilder<T>,
        IOutputPolicyEngineBuilder<T>,
        IPolicyEngineBuilder<T>
    {
        private IEnumerable<IInputPolicy<T>> _inputPolicies;
        private IEnumerable<IOutputPolicy<T>> _outputPolicies;
        private IEnumerable<IProcessor<T>> _processors;

        public static IInputPolicyEngineBuilder<T> Configure()
        {
            return new PolicyEngineBuilder<T>();
        }

        public IProcessorPolicyEngineBuilder<T> WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies)
        {
            _inputPolicies = inputPolicies;

            return this;
        }

        public IOutputPolicyEngineBuilder<T> WithProcessors(IEnumerable<IProcessor<T>> processors)
        {
            _processors = processors;

            return this;
        }

        public IPolicyEngineBuilder<T> WithOutputPolicies(IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _outputPolicies = outputPolicies;

            return this;
        }

        public IPolicyEngine<T> Build()
        {
            var policyEngine = new PolicyEngine<T>();

            policyEngine.SetInputPolicyRunner(new InputPolicyRunner<T>(_inputPolicies));
            policyEngine.SetProcessorRunner(new ProcessorRunner<T>(_processors));
            policyEngine.SetOutputPolicyRunner(new OutputPolicyRunner<T>(_outputPolicies));

            return policyEngine;
        }
    }
}