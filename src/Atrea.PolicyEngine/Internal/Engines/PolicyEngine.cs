using Atrea.PolicyEngine.Internal.PolicyRunners.Input;
using Atrea.PolicyEngine.Internal.PolicyRunners.Output;
using Atrea.PolicyEngine.Internal.ProcessorRunners;
using Atrea.PolicyEngine.Policies.Input;
using System.Collections.Generic;

namespace Atrea.PolicyEngine.Internal.Engines
{
    internal class PolicyEngine<T> : IPolicyEngine<T>
    {
        private readonly IInputPolicyRunner<T> _inputPolicyRunner;
        private readonly IProcessorRunner<T> _processorRunner;
        private readonly IOutputPolicyRunner<T> _outputPolicyRunner;

        public PolicyEngine(
            IInputPolicyRunner<T> inputPolicyRunner,
            IProcessorRunner<T> processorRunner,
            IOutputPolicyRunner<T> outputPolicyRunner)
        {
            _inputPolicyRunner = inputPolicyRunner;
            _processorRunner = processorRunner;
            _outputPolicyRunner = outputPolicyRunner;
        }

        public void Process(T item)
        {
            if (_inputPolicyRunner.ShouldProcess(item) == InputPolicyResult.Reject)
            {
                return;
            }

            _processorRunner.Process(item);
            _outputPolicyRunner.Apply(item);
        }

        public void Process(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Process(item);
            }
        }
    }
}