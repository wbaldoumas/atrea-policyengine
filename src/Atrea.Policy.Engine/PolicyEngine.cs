using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atrea.Policy.Engine.Policies.Input;
using Atrea.Policy.Engine.Policies.Output;
using Atrea.Policy.Engine.Processors;

namespace Atrea.Policy.Engine
{
    public abstract class PolicyEngine<T> : Processor<T>, IPolicyEngine<T>
    {
        private readonly IEnumerable<IInputPolicy<T>> _inputPolicies;
        private readonly IEnumerable<IOutputPolicy<T>> _outputPolicies;
        private readonly IEnumerable<Processor<T>> _processors;

        protected PolicyEngine(
            IEnumerable<IInputPolicy<T>> inputPolicies,
            IEnumerable<Processor<T>> processors,
            IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _inputPolicies = inputPolicies;
            _processors = processors;
            _outputPolicies = outputPolicies;
        }

        public async Task ProcessParallel(T item)
        {
            if (!EvaluateInputPolicies(item))
            {
                return;
            }

            var tasks = _processors.Select(processor => processor.ProcessAsync(item));

            await Task.WhenAll(tasks);

            ApplyOutputPolicies(item);
        }

        public override void Process(T item)
        {
            if (!EvaluateInputPolicies(item))
            {
                return;
            }

            foreach (var processor in _processors)
            {
                processor.Process(item);
            }

            ApplyOutputPolicies(item);
        }

        public override async Task ProcessAsync(T item)
        {
            if (!EvaluateInputPolicies(item))
            {
                return;
            }

            foreach (var processor in _processors)
            {
                await processor.ProcessAsync(item);
            }

            ApplyOutputPolicies(item);
        }

        private bool EvaluateInputPolicies(T item)
        {
            foreach (var inputPolicy in _inputPolicies)
            {
                switch (inputPolicy.ShouldProcess(item))
                {
                    case InputPolicyResult.Accept:
                        return true;
                    case InputPolicyResult.Reject:
                        return false;
                    case InputPolicyResult.Continue:
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return true;
        }

        private void ApplyOutputPolicies(T item)
        {
            foreach (var outputPolicy in _outputPolicies)
            {
                outputPolicy.Apply(item);
            }
        }
    }
}