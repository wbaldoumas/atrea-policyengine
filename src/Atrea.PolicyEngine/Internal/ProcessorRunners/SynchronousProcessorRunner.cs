using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Internal.ProcessorRunners
{
    internal class SynchronousProcessorRunner<T> : BaseProcessorRunnerDecorator<T>
    {
        private readonly IEnumerable<IProcessor<T>> _processors;

        public SynchronousProcessorRunner(
            IAsyncProcessorRunner<T> asyncProcessorRunner,
            IEnumerable<IProcessor<T>> processors)
            : base(asyncProcessorRunner) =>
            _processors = processors;

        protected override Task RunProcessors(T item)
        {
            var task = new Task(() =>
            {
                foreach (var processor in _processors)
                {
                    processor.Process(item);
                }
            });

            task.RunSynchronously(TaskScheduler.Default);

            return task;
        }
    }
}