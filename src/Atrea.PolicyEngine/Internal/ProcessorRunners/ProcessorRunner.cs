using System.Collections.Generic;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    internal class ProcessorRunner<T> : IProcessorRunner<T>
    {
        private readonly IEnumerable<IProcessor<T>> _processors;

        public ProcessorRunner(IEnumerable<IProcessor<T>> processors)
        {
            _processors = processors;
        }

        public void Process(T item)
        {
            foreach (var processor in _processors)
            {
                processor.Process(item);
            }
        }
    }
}