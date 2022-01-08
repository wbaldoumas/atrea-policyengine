using Atrea.PolicyEngine.Internal.PolicyRunners.Input;
using Atrea.PolicyEngine.Internal.PolicyRunners.Output;
using Atrea.PolicyEngine.Internal.ProcessorRunners;
using Atrea.PolicyEngine.Policies.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.Engines
{
    internal class AsyncPolicyEngine<T> : IAsyncPolicyEngine<T>
    {
        private readonly IAsyncInputPolicyRunner<T> _inputPolicyRunner;
        private readonly IAsyncProcessorRunner<T> _processorRunner;
        private readonly IAsyncOutputPolicyRunner<T> _outputPolicyRunner;

        internal AsyncPolicyEngine(
            IAsyncInputPolicyRunner<T> inputPolicyRunner,
            IAsyncProcessorRunner<T> processorRunner,
            IAsyncOutputPolicyRunner<T> outputPolicyRunner)
        {
            _inputPolicyRunner = inputPolicyRunner;
            _processorRunner = processorRunner;
            _outputPolicyRunner = outputPolicyRunner;
        }

        public async Task ProcessAsync(T item)
        {
            if (await _inputPolicyRunner.ShouldProcessAsync(item) == InputPolicyResult.Reject)
            {
                return;
            }

            await _processorRunner.ProcessAsync(item);
            await _outputPolicyRunner.ApplyAsync(item);
        }

        public async Task ProcessAsync(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                await ProcessAsync(item);
            }
        }

        public async Task ProcessParallelAsync(IEnumerable<T> items)
        {
            var tasks = items.Select(ProcessAsync);

            await Task.WhenAll(tasks);
        }
    }
}