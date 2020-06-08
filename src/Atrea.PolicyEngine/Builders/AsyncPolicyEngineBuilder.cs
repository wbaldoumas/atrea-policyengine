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
            WithInputPolicies(params IInputPolicy<T>[] inputPolicies) =>
            SetSynchronousInputPolicyRunnerDecorator(inputPolicies);

        IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithInputPolicies(
                params IInputPolicy<T>[] inputPolicies) =>
            SetSynchronousInputPolicyRunnerDecorator(inputPolicies);

        IProcessorAsyncPolicyEngineBuilder<T> IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithInputPolicies(params IInputPolicy<T>[] inputPolicies) =>
            SetSynchronousInputPolicyRunnerDecorator(inputPolicies);

        IWithSynchronousAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithInputPolicies(params IInputPolicy<T>[] inputPolicies) =>
            SetSynchronousInputPolicyRunnerDecorator(inputPolicies);

        private AsyncPolicyEngineBuilder<T> SetSynchronousInputPolicyRunnerDecorator(
            params IInputPolicy<T>[] inputPolicies)
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
            WithAsyncInputPolicies(params IAsyncInputPolicy<T>[] asyncInputPolicies) =>
            SetAsyncInputPolicyRunnerDecorator(asyncInputPolicies);

        IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithAsyncInputPolicies(
                params IAsyncInputPolicy<T>[] asyncInputPolicies) =>
            SetAsyncInputPolicyRunnerDecorator(asyncInputPolicies);

        IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> IInputPolicyAsyncPolicyEngineBuilder<T>.
            WithAsyncInputPolicies(params IAsyncInputPolicy<T>[] asyncInputPolicies) =>
            SetAsyncInputPolicyRunnerDecorator(asyncInputPolicies);

        IProcessorAsyncPolicyEngineBuilder<T>
            IWithParallelAndSynchronousInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithAsyncInputPolicies(
                params IAsyncInputPolicy<T>[] asyncInputPolicies) =>
            SetAsyncInputPolicyRunnerDecorator(asyncInputPolicies);

        private AsyncPolicyEngineBuilder<T> SetAsyncInputPolicyRunnerDecorator(
            params IAsyncInputPolicy<T>[] asyncInputPolicies)
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
                params IAsyncInputPolicy<T>[] parallelInputPolicies) =>
            SetParallelInputPolicyRunnerDecorator(parallelInputPolicies);

        IWithParallelInputPoliciesProcessorAsyncPolicyEngineBuilder<T> IInputPolicyAsyncPolicyEngineBuilder<T>.
            WithParallelInputPolicies(params IAsyncInputPolicy<T>[] parallelInputPolicies) =>
            SetParallelInputPolicyRunnerDecorator(parallelInputPolicies);

        IWithParallelAndAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>
            IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.WithParallelInputPolicies(
                params IAsyncInputPolicy<T>[] parallelInputPolicies) =>
            SetParallelInputPolicyRunnerDecorator(parallelInputPolicies);

        public IProcessorAsyncPolicyEngineBuilder<T> WithParallelInputPolicies(
            params IAsyncInputPolicy<T>[] parallelInputPolicies) =>
            SetParallelInputPolicyRunnerDecorator(parallelInputPolicies);

        private AsyncPolicyEngineBuilder<T> SetParallelInputPolicyRunnerDecorator(
            params IAsyncInputPolicy<T>[] parallelInputPolicies)
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
                params IProcessor<T>[] processors) =>
            SetSynchronousProcessorRunner(processors);

        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                params IProcessor<T>[] processors) =>
            SetSynchronousProcessorRunner(processors);

        IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.WithProcessors(
            params IProcessor<T>[] processors) =>
            SetSynchronousProcessorRunner(processors);

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                params IProcessor<T>[] processors) =>
            SetSynchronousProcessorRunner(processors);

        private AsyncPolicyEngineBuilder<T> SetSynchronousProcessorRunner(params IProcessor<T>[] processors)
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
            WithAsyncProcessors(params IAsyncProcessor<T>[] asyncProcessors) =>
            SetAsyncProcessorRunnerDecorator(asyncProcessors);

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                params IAsyncProcessor<T>[] asyncProcessors) =>
            SetAsyncProcessorRunnerDecorator(asyncProcessors);

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                params IAsyncProcessor<T>[] asyncProcessors) =>
            SetAsyncProcessorRunnerDecorator(asyncProcessors);

        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                params IAsyncProcessor<T>[] asyncProcessors) =>
            SetAsyncProcessorRunnerDecorator(asyncProcessors);

        private AsyncPolicyEngineBuilder<T> SetAsyncProcessorRunnerDecorator(
            params IAsyncProcessor<T>[] asyncProcessors)
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
                params IAsyncProcessor<T>[] parallelProcessors) =>
            SetParallelProcessorRunnerDecorator(parallelProcessors);

        IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.
            WithParallelProcessors(params IAsyncProcessor<T>[] parallelProcessors) =>
            SetParallelProcessorRunnerDecorator(parallelProcessors);

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                params IAsyncProcessor<T>[] parallelProcessors) =>
            SetParallelProcessorRunnerDecorator(parallelProcessors);

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                params IAsyncProcessor<T>[] parallelProcessors) =>
            SetParallelProcessorRunnerDecorator(parallelProcessors);

        private AsyncPolicyEngineBuilder<T> SetParallelProcessorRunnerDecorator(
            params IAsyncProcessor<T>[] parallelProcessors)
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
            WithOutputPolicies(params IOutputPolicy<T>[] outputPolicies) =>
            SetSynchronousOutputPolicyRunnerDecorator(outputPolicies);

        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>
            IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
                params IOutputPolicy<T>[] outputPolicies) =>
            SetSynchronousOutputPolicyRunnerDecorator(outputPolicies);

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
                params IOutputPolicy<T>[] outputPolicies) =>
            SetSynchronousOutputPolicyRunnerDecorator(outputPolicies);

        IWithOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
            params IOutputPolicy<T>[] outputPolicies) =>
            SetSynchronousOutputPolicyRunnerDecorator(outputPolicies);

        private AsyncPolicyEngineBuilder<T> SetSynchronousOutputPolicyRunnerDecorator(
            params IOutputPolicy<T>[] outputPolicies)
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
            WithAsyncOutputPolicies(params IAsyncOutputPolicy<T>[] asyncOutputPolicies) =>
            SetAsyncOutputPolicyRunnerDecorator(asyncOutputPolicies);

        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> IWithOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(params IAsyncOutputPolicy<T>[] asyncOutputPolicies) =>
            SetAsyncOutputPolicyRunnerDecorator(asyncOutputPolicies);

        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.WithAsyncOutputPolicies(
                params IAsyncOutputPolicy<T>[] asyncOutputPolicies) =>
            SetAsyncOutputPolicyRunnerDecorator(asyncOutputPolicies);

        IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(params IAsyncOutputPolicy<T>[] asyncOutputPolicies) =>
            SetAsyncOutputPolicyRunnerDecorator(asyncOutputPolicies);

        private AsyncPolicyEngineBuilder<T> SetAsyncOutputPolicyRunnerDecorator(
            params IAsyncOutputPolicy<T>[] asyncOutputPolicies)
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
                params IAsyncOutputPolicy<T>[] parallelOutputPolicies) =>
            SetParallelOutputPolicyRunner(parallelOutputPolicies);

        IAsyncPolicyEngineBuilder<T> IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>.
            WithParallelOutputPolicies(params IAsyncOutputPolicy<T>[] parallelOutputPolicies) =>
            SetParallelOutputPolicyRunner(parallelOutputPolicies);

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithOutputPoliciesAsyncPolicyEngineBuilder<T>.WithParallelOutputPolicies(
                params IAsyncOutputPolicy<T>[] parallelOutputPolicies) =>
            SetParallelOutputPolicyRunner(parallelOutputPolicies);

        IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.
            WithParallelOutputPolicies(params IAsyncOutputPolicy<T>[] parallelOutputPolicies) =>
            SetParallelOutputPolicyRunner(parallelOutputPolicies);

        private AsyncPolicyEngineBuilder<T> SetParallelOutputPolicyRunner(
            params IAsyncOutputPolicy<T>[] parallelOutputPolicies)
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