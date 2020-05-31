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
    ///     A builder class for configuring and building an <see cref="IAsyncPolicyEngine{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the item to be processed by the <see cref="IAsyncPolicyEngine{T}"/></typeparam>
    public class AsyncPolicyEngineBuilder<T> :
        IInputPolicyAsyncPolicyEngineBuilder<T>,
        IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T>,
        IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>,
        IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>,
        IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>,
        IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>,
        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>,
        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>,
        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>,
        IWithOutputPoliciesAsyncPolicyEngineBuilder<T>,
        IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T>,
        IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>,
        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>,
        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>,
        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
    {
        private IEnumerable<IAsyncInputPolicy<T>> _asyncInputPolicies = new List<IAsyncInputPolicy<T>>();
        private IEnumerable<IAsyncOutputPolicy<T>> _asyncOutputPolicies = new List<IAsyncOutputPolicy<T>>();
        private IEnumerable<IAsyncProcessor<T>> _asyncProcessors = new List<IAsyncProcessor<T>>();
        private IEnumerable<IInputPolicy<T>> _inputPolicies = new List<IInputPolicy<T>>();
        private IEnumerable<IOutputPolicy<T>> _outputPolicies = new List<IOutputPolicy<T>>();
        private IEnumerable<IAsyncOutputPolicy<T>> _parallelOutputPolicies = new List<IAsyncOutputPolicy<T>>();
        private IEnumerable<IAsyncProcessor<T>> _parallelProcessors = new List<IAsyncProcessor<T>>();
        private IEnumerable<IProcessor<T>> _processors = new List<IProcessor<T>>();

        /// <summary>
        ///     Begin configuring a <see cref="IAsyncPolicyEngine{T}"/>.
        /// </summary>
        /// <returns><see cref="IInputPolicyAsyncPolicyEngineBuilder{T}"/></returns>
        public static IInputPolicyAsyncPolicyEngineBuilder<T> Configure()
        {
            return new AsyncPolicyEngineBuilder<T>();
        }

        #region WithInputPolicies

        IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T> IInputPolicyAsyncPolicyEngineBuilder<T>.
            WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies)
        {
            _inputPolicies = inputPolicies;

            return this;
        }

        IProcessorAsyncPolicyEngineBuilder<T> IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies)
        {
            _inputPolicies = inputPolicies;

            return this;
        }

        #endregion

        #region WithAsyncInputPolicies

        IProcessorAsyncPolicyEngineBuilder<T> IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithAsyncInputPolicies(IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies)
        {
            _asyncInputPolicies = asyncInputPolicies;

            return this;
        }

        IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> IInputPolicyAsyncPolicyEngineBuilder<T>.
            WithAsyncInputPolicies(IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies)
        {
            _asyncInputPolicies = asyncInputPolicies;

            return this;
        }

        #endregion

        #region WithProcessors

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors)
        {
            _processors = processors;

            return this;
        }

        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors)
        {
            _processors = processors;

            return this;
        }

        IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.WithProcessors(
            IEnumerable<IProcessor<T>> processors)
        {
            _processors = processors;

            return this;
        }

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors)
        {
            _processors = processors;

            return this;
        }

        #endregion

        #region WithAsyncProcessors

        IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.
            WithAsyncProcessors(IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessors = asyncProcessors;

            return this;
        }

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessors = asyncProcessors;

            return this;
        }

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessors = asyncProcessors;

            return this;
        }

        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessors = asyncProcessors;

            return this;
        }

        #endregion

        #region WithParallelProcessors

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _parallelProcessors = parallelProcessors;

            return this;
        }

        IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.
            WithParallelProcessors(IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _parallelProcessors = parallelProcessors;

            return this;
        }

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _parallelProcessors = parallelProcessors;

            return this;
        }

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _parallelProcessors = parallelProcessors;

            return this;
        }

        #endregion

        #region WithOutputPolicies

        IAsyncPolicyEngineBuilder<T> IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithOutputPolicies(IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _outputPolicies = outputPolicies;

            return this;
        }

        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>
            IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
                IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _outputPolicies = outputPolicies;

            return this;
        }

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
                IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _outputPolicies = outputPolicies;

            return this;
        }

        IWithOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
            IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _outputPolicies = outputPolicies;

            return this;
        }

        #endregion

        #region WithAsyncOutputPolicies

        IAsyncPolicyEngineBuilder<T> IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
        {
            _asyncOutputPolicies = asyncOutputPolicies;

            return this;
        }

        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> IWithOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
        {
            _asyncOutputPolicies = asyncOutputPolicies;

            return this;
        }

        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.WithAsyncOutputPolicies(
                IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
        {
            _asyncOutputPolicies = asyncOutputPolicies;

            return this;
        }

        IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
        {
            _asyncOutputPolicies = asyncOutputPolicies;

            return this;
        }

        #endregion

        #region WithParallelOutputPolicies

        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T>.WithParallelOutputPolicies(
                IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _parallelOutputPolicies = parallelOutputPolicies;

            return this;
        }

        IAsyncPolicyEngineBuilder<T> IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>.
            WithParallelOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _parallelOutputPolicies = parallelOutputPolicies;

            return this;
        }

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithOutputPoliciesAsyncPolicyEngineBuilder<T>.WithParallelOutputPolicies(
                IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _parallelOutputPolicies = parallelOutputPolicies;

            return this;
        }

        IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.
            WithParallelOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _parallelOutputPolicies = parallelOutputPolicies;

            return this;
        }

        #endregion

        public IAsyncPolicyEngine<T> Build()
        {
            var policyEngine = new AsyncPolicyEngine<T>();

            policyEngine.SetInputPolicyRunner(BuildAggregateAsyncInputPolicyRunner());
            policyEngine.SetProcessorRunner(BuildAggregateAsyncProcessorRunner());
            policyEngine.SetOutputPolicyRunner(BuildAggregateAsyncOutputPolicyRunner());

            return policyEngine;
        }

        private AggregateAsyncInputPolicyRunner<T> BuildAggregateAsyncInputPolicyRunner()
        {
            var inputPolicyRunner = new InputPolicyRunner<T>(_inputPolicies);
            var asyncInputPolicyRunner = new AsyncInputPolicyRunner<T>(_asyncInputPolicies);

            return new AggregateAsyncInputPolicyRunner<T>(
                inputPolicyRunner,
                asyncInputPolicyRunner
            );
        }

        private AggregateAsyncProcessorRunner<T> BuildAggregateAsyncProcessorRunner()
        {
            var processorRunner = new ProcessorRunner<T>(_processors);
            var asyncProcessorRunner = new AsyncProcessorRunner<T>(_asyncProcessors);
            var parallelProcessorRunner = new ParallelProcessorRunner<T>(_parallelProcessors);

            return new AggregateAsyncProcessorRunner<T>(
                processorRunner,
                asyncProcessorRunner,
                parallelProcessorRunner
            );
        }

        private AggregateAsyncOutputPolicyRunner<T> BuildAggregateAsyncOutputPolicyRunner()
        {
            var outputPolicyRunner = new OutputPolicyRunner<T>(_outputPolicies);
            var asyncOutputPolicyRunner = new AsyncOutputPolicyRunner<T>(_asyncOutputPolicies);
            var parallelOutputPolicyRunner = new ParallelOutputPolicyRunner<T>(_parallelOutputPolicies);

            return new AggregateAsyncOutputPolicyRunner<T>(
                outputPolicyRunner,
                asyncOutputPolicyRunner,
                parallelOutputPolicyRunner
            );
        }
    }
}