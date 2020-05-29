using Atrea.PolicyEngine.Internal.PolicyRunners.Input;
using Atrea.PolicyEngine.Internal.PolicyRunners.Output;
using Atrea.PolicyEngine.Internal.ProcessorRunners;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.Engines
{
    internal class PolicyEngine<T> : IPolicyEngine<T>
    {
        private IInputPolicyRunner<T> _inputPolicyRunner;
        private IOutputPolicyRunner<T> _outputPolicyRunner;
        private IProcessorRunner<T> _processorRunner;

        public void Process(T item)
        {
            if (_inputPolicyRunner.ShouldProcess(item) == InputPolicyResult.Reject)
            {
                return;
            }

            _processorRunner.Process(item);
            _outputPolicyRunner.Apply(item);
        }

        public void SetInputPolicyRunner(IInputPolicyRunner<T> inputPolicyRunner)
        {
            _inputPolicyRunner = inputPolicyRunner;
        }

        public void SetProcessorRunner(IProcessorRunner<T> processorRunner)
        {
            _processorRunner = processorRunner;
        }

        public void SetOutputPolicyRunner(IOutputPolicyRunner<T> outputPolicyRunner)
        {
            _outputPolicyRunner = outputPolicyRunner;
        }
    }
}