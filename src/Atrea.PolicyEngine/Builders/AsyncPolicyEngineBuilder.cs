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
    ///     A builder class for configuring and building an <see cref="IAsyncPolicyEngine{T}" />.
    /// </summary>
    /// <typeparam name="T">The type of the item to be processed by the <see cref="IAsyncPolicyEngine{T}" /></typeparam>
    public class AsyncPolicyEngineBuilder<T> :
        IInputPolicyAsyncPolicyEngineBuilder<T>,
        IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T>,
        IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>,
        IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T>,
        IWithSynchronousAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>,
        IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T>,
        IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>,
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
        private IAsyncInputPolicyRunner<T> _asyncInputPolicyRunner = new RootAsyncInputPolicyRunner<T>();
        private IAsyncOutputPolicyRunner<T> _asyncOutputPolicyRunner = new RootAsyncOutputPolicyRunner<T>();
        private IAsyncProcessorRunner<T> _asyncProcessorRunner = new RootAsyncProcessorRunner<T>();

        public IAsyncPolicyEngine<T> Build()
        {
            var policyEngine = new AsyncPolicyEngine<T>();

            policyEngine.SetInputPolicyRunner(_asyncInputPolicyRunner);
            policyEngine.SetProcessorRunner(_asyncProcessorRunner);
            policyEngine.SetOutputPolicyRunner(_asyncOutputPolicyRunner);

            return policyEngine;
        }

        /// <summary>
        ///     Begin configuring a <see cref="IAsyncPolicyEngine{T}" />.
        /// </summary>
        /// <returns>
        ///     <see cref="IInputPolicyAsyncPolicyEngineBuilder{T}" />
        /// </returns>
        public static IInputPolicyAsyncPolicyEngineBuilder<T> Configure() => new AsyncPolicyEngineBuilder<T>();

        #region WithInputPolicies

        IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T> IInputPolicyAsyncPolicyEngineBuilder<T>.
            WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies) =>
            SetSynchronousInputPolicyRunnerDecorator(inputPolicies);

        IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithInputPolicies(
                IEnumerable<IInputPolicy<T>> inputPolicies) =>
            SetSynchronousInputPolicyRunnerDecorator(inputPolicies);

        IProcessorAsyncPolicyEngineBuilder<T> IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies) =>
            SetSynchronousInputPolicyRunnerDecorator(inputPolicies);

        IWithSynchronousAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies) =>
            SetSynchronousInputPolicyRunnerDecorator(inputPolicies);

        private AsyncPolicyEngineBuilder<T> SetSynchronousInputPolicyRunnerDecorator(
            IEnumerable<IInputPolicy<T>> inputPolicies)
        {
            _asyncInputPolicyRunner = new SynchronousInputPolicyRunnerDecorator<T>(
                _asyncInputPolicyRunner,
                inputPolicies
            );

            return this;
        }

        public IProcessorAsyncPolicyEngineBuilder<T> WithoutInputPolicies() => this;

        #endregion

        #region WithAsyncInputPolicies

        IWithSynchronousAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithAsyncInputPolicies(IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies) =>
            SetAsyncInputPolicyRunnerDecorator(asyncInputPolicies);

        IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithAsyncInputPolicies(
                IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies) =>
            SetAsyncInputPolicyRunnerDecorator(asyncInputPolicies);

        IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> IInputPolicyAsyncPolicyEngineBuilder<T>.
            WithAsyncInputPolicies(IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies) =>
            SetAsyncInputPolicyRunnerDecorator(asyncInputPolicies);

        IProcessorAsyncPolicyEngineBuilder<T>
            IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithAsyncInputPolicies(
                IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies) =>
            SetAsyncInputPolicyRunnerDecorator(asyncInputPolicies);

        private AsyncPolicyEngineBuilder<T> SetAsyncInputPolicyRunnerDecorator(
            IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies)
        {
            _asyncInputPolicyRunner = new AsyncInputPolicyRunnerDecorator<T>(
                _asyncInputPolicyRunner,
                asyncInputPolicies
            );

            return this;
        }

        #endregion

        #region WithParallelInputPolicies

        IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithParallelInputPolicies(
                IEnumerable<IAsyncInputPolicy<T>> parallelInputPolicies) =>
            SetParallelInputPolicyRunnerDecorator(parallelInputPolicies);

        IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T> IInputPolicyAsyncPolicyEngineBuilder<T>.
            WithParallelInputPolicies(IEnumerable<IAsyncInputPolicy<T>> parallelInputPolicies) =>
            SetParallelInputPolicyRunnerDecorator(parallelInputPolicies);

        IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithParallelInputPolicies(
                IEnumerable<IAsyncInputPolicy<T>> parallelInputPolicies) =>
            SetParallelInputPolicyRunnerDecorator(parallelInputPolicies);

        public IProcessorAsyncPolicyEngineBuilder<T> WithParallelInputPolicies(
            IEnumerable<IAsyncInputPolicy<T>> parallelInputPolicies) =>
            SetParallelInputPolicyRunnerDecorator(parallelInputPolicies);

        private AsyncPolicyEngineBuilder<T> SetParallelInputPolicyRunnerDecorator(
            IEnumerable<IAsyncInputPolicy<T>> parallelInputPolicies)
        {
            _asyncInputPolicyRunner = new ParallelInputPolicyRunnerDecorator<T>(
                _asyncInputPolicyRunner,
                parallelInputPolicies
            );

            return this;
        }

        #endregion

        #region WithProcessors

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors) =>
            SetSynchronousProcessorRunner(processors);

        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors) =>
            SetSynchronousProcessorRunner(processors);

        IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.WithProcessors(
            IEnumerable<IProcessor<T>> processors) =>
            SetSynchronousProcessorRunner(processors);

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors) =>
            SetSynchronousProcessorRunner(processors);

        private AsyncPolicyEngineBuilder<T> SetSynchronousProcessorRunner(IEnumerable<IProcessor<T>> processors)
        {
            _asyncProcessorRunner = new SynchronousProcessorRunner<T>(
                _asyncProcessorRunner,
                processors
            );

            return this;
        }

        public IOutputPolicyAsyncPolicyEngineBuilder<T> WithoutProcessors() => this;

        #endregion

        #region WithAsyncProcessors

        IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.
            WithAsyncProcessors(IEnumerable<IAsyncProcessor<T>> asyncProcessors) =>
            SetAsyncProcessorRunnerDecorator(asyncProcessors);

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors) =>
            SetAsyncProcessorRunnerDecorator(asyncProcessors);

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors) =>
            SetAsyncProcessorRunnerDecorator(asyncProcessors);

        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors) =>
            SetAsyncProcessorRunnerDecorator(asyncProcessors);

        private AsyncPolicyEngineBuilder<T> SetAsyncProcessorRunnerDecorator(
            IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessorRunner = new AsyncProcessorRunnerDecorator<T>(
                _asyncProcessorRunner,
                asyncProcessors
            );

            return this;
        }

        #endregion

        #region WithParallelProcessors

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors) =>
            SetParallelProcessorRunnerDecorator(parallelProcessors);

        IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.
            WithParallelProcessors(IEnumerable<IAsyncProcessor<T>> parallelProcessors) =>
            SetParallelProcessorRunnerDecorator(parallelProcessors);

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors) =>
            SetParallelProcessorRunnerDecorator(parallelProcessors);

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors) =>
            SetParallelProcessorRunnerDecorator(parallelProcessors);

        private AsyncPolicyEngineBuilder<T> SetParallelProcessorRunnerDecorator(
            IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _asyncProcessorRunner = new ParallelProcessorRunnerDecorator<T>(
                _asyncProcessorRunner,
                parallelProcessors
            );

            return this;
        }

        #endregion

        #region WithOutputPolicies

        IAsyncPolicyEngineBuilder<T> IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithOutputPolicies(IEnumerable<IOutputPolicy<T>> outputPolicies) =>
            SetSynchronousOutputPolicyRunnerDecorator(outputPolicies);

        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>
            IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
                IEnumerable<IOutputPolicy<T>> outputPolicies) =>
            SetSynchronousOutputPolicyRunnerDecorator(outputPolicies);

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
                IEnumerable<IOutputPolicy<T>> outputPolicies) =>
            SetSynchronousOutputPolicyRunnerDecorator(outputPolicies);

        IWithOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
            IEnumerable<IOutputPolicy<T>> outputPolicies) =>
            SetSynchronousOutputPolicyRunnerDecorator(outputPolicies);

        private AsyncPolicyEngineBuilder<T> SetSynchronousOutputPolicyRunnerDecorator(
            IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _asyncOutputPolicyRunner = new SynchronousOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                outputPolicies
            );

            return this;
        }

        public IAsyncPolicyEngineBuilder<T> WithoutOutputPolicies() => this;

        #endregion

        #region WithAsyncOutputPolicies

        IAsyncPolicyEngineBuilder<T> IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies) =>
            SetAsyncOutputPolicyRunnerDecorator(asyncOutputPolicies);

        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> IWithOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies) =>
            SetAsyncOutputPolicyRunnerDecorator(asyncOutputPolicies);

        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.WithAsyncOutputPolicies(
                IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies) =>
            SetAsyncOutputPolicyRunnerDecorator(asyncOutputPolicies);

        IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies) =>
            SetAsyncOutputPolicyRunnerDecorator(asyncOutputPolicies);

        private AsyncPolicyEngineBuilder<T> SetAsyncOutputPolicyRunnerDecorator(
            IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
        {
            _asyncOutputPolicyRunner = new AsyncOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                asyncOutputPolicies
            );

            return this;
        }

        #endregion

        #region WithParallelOutputPolicies

        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T>.WithParallelOutputPolicies(
                IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies) =>
            SetParallelOutputPolicyRunner(parallelOutputPolicies);

        IAsyncPolicyEngineBuilder<T> IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>.
            WithParallelOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies) =>
            SetParallelOutputPolicyRunner(parallelOutputPolicies);

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithOutputPoliciesAsyncPolicyEngineBuilder<T>.WithParallelOutputPolicies(
                IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies) =>
            SetParallelOutputPolicyRunner(parallelOutputPolicies);

        IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.
            WithParallelOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies) =>
            SetParallelOutputPolicyRunner(parallelOutputPolicies);

        private AsyncPolicyEngineBuilder<T> SetParallelOutputPolicyRunner(
            IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _asyncOutputPolicyRunner = new ParallelOutputPolicyRunner<T>(
                _asyncOutputPolicyRunner,
                parallelOutputPolicies
            );

            return this;
        }

        #endregion
    }
}