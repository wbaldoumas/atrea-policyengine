using Atrea.PolicyEngine.Internal.Engines;
using Atrea.PolicyEngine.Internal.PolicyRunners.Input;
using Atrea.PolicyEngine.Internal.PolicyRunners.Output;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;
using Atrea.PolicyEngine.Internal.ProcessorRunners;

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
        private IAsyncInputPolicyRunner<T> _asyncInputPolicyRunner;
        private IAsyncProcessorRunner<T> _asyncProcessorRunner;
        private IAsyncOutputPolicyRunner<T> _asyncOutputPolicyRunner;

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
            _asyncInputPolicyRunner = new SynchronousInputPolicyRunnerDecorator<T>(
                _asyncInputPolicyRunner,
                inputPolicies
            );

            return this;
        }

        IProcessorAsyncPolicyEngineBuilder<T> IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies)
        {
            _asyncInputPolicyRunner = new SynchronousInputPolicyRunnerDecorator<T>(
                _asyncInputPolicyRunner,
                inputPolicies
            );

            return this;
        }

        #endregion

        #region WithAsyncInputPolicies

        IProcessorAsyncPolicyEngineBuilder<T> IWithInputPoliciesProcessorAsyncPolicyEngineBuilder<T>.
            WithAsyncInputPolicies(IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies)
        {
            _asyncInputPolicyRunner = new AsyncInputPolicyRunnerDecorator<T>(
                _asyncInputPolicyRunner,
                asyncInputPolicies
            );

            return this;
        }

        IWithAsyncInputPoliciesProcessorAsyncPolicyEngineBuilder<T> IInputPolicyAsyncPolicyEngineBuilder<T>.
            WithAsyncInputPolicies(IEnumerable<IAsyncInputPolicy<T>> asyncInputPolicies)
        {
            _asyncInputPolicyRunner = new AsyncInputPolicyRunnerDecorator<T>(
                _asyncInputPolicyRunner,
                asyncInputPolicies
            );

            return this;
        }

        #endregion

        #region WithProcessors

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors)
        {
            _asyncProcessorRunner = new SynchronousAsyncProcessorRunner<T>(_asyncProcessorRunner, processors);

            return this;
        }

        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors)
        {
            _asyncProcessorRunner = new SynchronousAsyncProcessorRunner<T>(_asyncProcessorRunner, processors);

            return this;
        }

        IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.WithProcessors(
            IEnumerable<IProcessor<T>> processors)
        {
            _asyncProcessorRunner = new SynchronousAsyncProcessorRunner<T>(_asyncProcessorRunner, processors);

            return this;
        }

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithProcessors(
                IEnumerable<IProcessor<T>> processors)
        {
            _asyncProcessorRunner = new SynchronousAsyncProcessorRunner<T>(_asyncProcessorRunner, processors);

            return this;
        }

        #endregion

        #region WithAsyncProcessors

        IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.
            WithAsyncProcessors(IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessorRunner = new AsyncProcessorRunnerDecorator<T>(_asyncProcessorRunner, asyncProcessors);

            return this;
        }

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessorRunner = new AsyncProcessorRunnerDecorator<T>(_asyncProcessorRunner, asyncProcessors);

            return this;
        }

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessorRunner = new AsyncProcessorRunnerDecorator<T>(_asyncProcessorRunner, asyncProcessors);

            return this;
        }

        IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithAsyncProcessors(
                IEnumerable<IAsyncProcessor<T>> asyncProcessors)
        {
            _asyncProcessorRunner = new AsyncProcessorRunnerDecorator<T>(_asyncProcessorRunner, asyncProcessors);

            return this;
        }

        #endregion

        #region WithParallelProcessors

        IWithAsyncProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _asyncProcessorRunner = new ParallelProcessorRunnerDecorator<T>(_asyncProcessorRunner, parallelProcessors);

            return this;
        }

        IWithParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T> IProcessorAsyncPolicyEngineBuilder<T>.
            WithParallelProcessors(IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _asyncProcessorRunner = new ParallelProcessorRunnerDecorator<T>(_asyncProcessorRunner, parallelProcessors);

            return this;
        }

        IOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsAndAsyncProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _asyncProcessorRunner = new ParallelProcessorRunnerDecorator<T>(_asyncProcessorRunner, parallelProcessors);

            return this;
        }

        IWithProcessorsAndParallelProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>
            IWithProcessorsOutputPolicyAsyncPolicyEngineBuilder<T>.WithParallelProcessors(
                IEnumerable<IAsyncProcessor<T>> parallelProcessors)
        {
            _asyncProcessorRunner = new ParallelProcessorRunnerDecorator<T>(_asyncProcessorRunner, parallelProcessors);

            return this;
        }

        #endregion

        #region WithOutputPolicies

        IAsyncPolicyEngineBuilder<T> IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithOutputPolicies(IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _asyncOutputPolicyRunner = new SynchronousAsyncOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                outputPolicies
            );

            return this;
        }

        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>
            IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
                IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _asyncOutputPolicyRunner = new SynchronousAsyncOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                outputPolicies
            );

            return this;
        }

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
                IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _asyncOutputPolicyRunner = new SynchronousAsyncOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                outputPolicies
            );

            return this;
        }

        IWithOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.WithOutputPolicies(
            IEnumerable<IOutputPolicy<T>> outputPolicies)
        {
            _asyncOutputPolicyRunner = new SynchronousAsyncOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                outputPolicies
            );

            return this;
        }

        #endregion

        #region WithAsyncOutputPolicies

        IAsyncPolicyEngineBuilder<T> IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
        {
            _asyncOutputPolicyRunner = new AsyncOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                asyncOutputPolicies
            );

            return this;
        }

        IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T> IWithOutputPoliciesAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
        {
            _asyncOutputPolicyRunner = new AsyncOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                asyncOutputPolicies
            );

            return this;
        }

        IWithAsyncOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T>.WithAsyncOutputPolicies(
                IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
        {
            _asyncOutputPolicyRunner = new AsyncOutputPolicyRunnerDecorator<T>(
                _asyncOutputPolicyRunner,
                asyncOutputPolicies
            );

            return this;
        }

        IWithAsyncOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.
            WithAsyncOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> asyncOutputPolicies)
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
                IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _asyncOutputPolicyRunner = new ParallelAsyncOutputPolicyRunner<T>(
                _asyncOutputPolicyRunner,
                parallelOutputPolicies
            );

            return this;
        }

        IAsyncPolicyEngineBuilder<T> IWithOutputPoliciesAndAsyncOutputPoliciesPolicyEngineBuilder<T>.
            WithParallelOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _asyncOutputPolicyRunner = new ParallelAsyncOutputPolicyRunner<T>(
                _asyncOutputPolicyRunner,
                parallelOutputPolicies
            );

            return this;
        }

        IWithOutputPoliciesAndParallelOutputPoliciesAsyncPolicyEngineBuilder<T>
            IWithOutputPoliciesAsyncPolicyEngineBuilder<T>.WithParallelOutputPolicies(
                IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _asyncOutputPolicyRunner = new ParallelAsyncOutputPolicyRunner<T>(
                _asyncOutputPolicyRunner,
                parallelOutputPolicies
            );

            return this;
        }

        IWithParallelOutputPoliciesAsyncPolicyEngineBuilder<T> IOutputPolicyAsyncPolicyEngineBuilder<T>.
            WithParallelOutputPolicies(IEnumerable<IAsyncOutputPolicy<T>> parallelOutputPolicies)
        {
            _asyncOutputPolicyRunner = new ParallelAsyncOutputPolicyRunner<T>(
                _asyncOutputPolicyRunner,
                parallelOutputPolicies
            );

            return this;
        }

        #endregion

        public IAsyncPolicyEngine<T> Build()
        {
            var policyEngine = new AsyncPolicyEngine<T>();

            policyEngine.SetInputPolicyRunner(_asyncInputPolicyRunner);
            policyEngine.SetProcessorRunner(_asyncProcessorRunner);
            policyEngine.SetOutputPolicyRunner(_asyncOutputPolicyRunner);

            return policyEngine;
        }
    }
}