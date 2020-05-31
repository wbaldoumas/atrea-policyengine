using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Tests.Builders
{
    [TestFixture]
    public class AsyncPolicyEngineBuilderTests
    {
        private const int Item = 1;

        private IInputPolicy<int> _mockInputPolicy;
        private IAsyncInputPolicy<int> _mockAsyncInputPolicy;
        private IProcessor<int> _mockProcessor;
        private IAsyncProcessor<int> _mockAsyncProcessor;
        private IAsyncProcessor<int> _mockParallelProcessor;
        private IOutputPolicy<int> _mockOutputPolicy;
        private IAsyncOutputPolicy<int> _mockAsyncOutputPolicy;
        private IAsyncOutputPolicy<int> _mockParallelOutputPolicy;

        [SetUp]
        public void SetUp()
        {
            _mockInputPolicy = Substitute.For<IInputPolicy<int>>();
            _mockAsyncInputPolicy = Substitute.For<IAsyncInputPolicy<int>>();

            _mockInputPolicy.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(InputPolicyResult.Continue));

            _mockProcessor = Substitute.For<IProcessor<int>>();
            _mockAsyncProcessor = Substitute.For<IAsyncProcessor<int>>();
            _mockParallelProcessor = Substitute.For<IAsyncProcessor<int>>();

            _mockOutputPolicy = Substitute.For<IOutputPolicy<int>>();
            _mockAsyncOutputPolicy = Substitute.For<IAsyncOutputPolicy<int>>();
            _mockParallelOutputPolicy = Substitute.For<IAsyncOutputPolicy<int>>();
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_A()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_B()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_C()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_D()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_E()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_F()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_G()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_H()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_I()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_J()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }
    }
}