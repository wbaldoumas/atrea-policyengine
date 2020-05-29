using System.Threading.Tasks;
using Atrea.PolicyEngine.Internal.PolicyRunners.Input;
using Atrea.PolicyEngine.Internal.PolicyRunners.Output;
using Atrea.PolicyEngine.Internal.ProcessorRunners;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Internal.Engines
{
    internal class AsyncPolicyEngine<T> : IAsyncPolicyEngine<T>
    {
        private IAsyncInputPolicyRunner<T> _inputPolicyRunner;
        private IAsyncOutputPolicyRunner<T> _outputPolicyRunner;
        private IAsyncProcessorRunner<T> _processorRunner;

        public async Task ProcessAsync(T item)
        {
            if (await _inputPolicyRunner.ShouldProcessAsync(item) == InputPolicyResult.Reject)
            {
                return;
            }

            await _processorRunner.ProcessAsync(item);
            await _outputPolicyRunner.ApplyAsync(item);
        }

        public void SetInputPolicyRunner(IAsyncInputPolicyRunner<T> inputPolicyRunner)
        {
            _inputPolicyRunner = inputPolicyRunner;
        }

        public void SetProcessorRunner(IAsyncProcessorRunner<T> processorRunner)
        {
            _processorRunner = processorRunner;
        }

        public void SetOutputPolicyRunner(IAsyncOutputPolicyRunner<T> outputPolicyRunner)
        {
            _outputPolicyRunner = outputPolicyRunner;
        }
    }
}