using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Engines
{
    [TestFixture]
    public class AsyncPolicyEngineTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockInputPolicyA = Substitute.For<IInputPolicy<int>>();
            _mockInputPolicyB = Substitute.For<IInputPolicy<int>>();
            _mockAsyncInputPolicyA = Substitute.For<IAsyncInputPolicy<int>>();
            _mockAsyncInputPolicyB = Substitute.For<IAsyncInputPolicy<int>>();
            _mockParallelInputPolicyA = Substitute.For<IAsyncInputPolicy<int>>();
            _mockParallelInputPolicyB = Substitute.For<IAsyncInputPolicy<int>>();

            _mockProcessor = Substitute.For<IProcessor<int>>();
            _mockAsyncProcessor = Substitute.For<IAsyncProcessor<int>>();

            _mockOutputPolicy = Substitute.For<IOutputPolicy<int>>();
            _mockAsyncOutputPolicy = Substitute.For<IAsyncOutputPolicy<int>>();
        }

        private const int Item = 1;

        private IInputPolicy<int> _mockInputPolicyA;
        private IInputPolicy<int> _mockInputPolicyB;
        private IAsyncInputPolicy<int> _mockAsyncInputPolicyA;
        private IAsyncInputPolicy<int> _mockAsyncInputPolicyB;
        private IAsyncInputPolicy<int> _mockParallelInputPolicyA;
        private IAsyncInputPolicy<int> _mockParallelInputPolicyB;

        private IProcessor<int> _mockProcessor;
        private IAsyncProcessor<int> _mockAsyncProcessor;

        private IOutputPolicy<int> _mockOutputPolicy;
        private IAsyncOutputPolicy<int> _mockAsyncOutputPolicy;

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order()
        {
            // arrange
            _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockAsyncInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));

            var engine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockAsyncInputPolicyA, _mockAsyncInputPolicyB })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockParallelInputPolicyA, _mockParallelInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            // act
            await engine.ProcessAsync(Item);

            // assert
            Received.InOrder(() =>
            {
                _mockAsyncInputPolicyA.ShouldProcessAsync(Item);
                _mockAsyncInputPolicyB.ShouldProcessAsync(Item);
                _mockInputPolicyA.ShouldProcess(Item);
                _mockInputPolicyB.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });

            await _mockParallelInputPolicyA.Received(1).ShouldProcessAsync(Item);
            await _mockParallelInputPolicyB.Received(1).ShouldProcessAsync(Item);
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_B()
        {
            // arrange
            _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Accept);
            _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockAsyncInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));

            var engine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockAsyncInputPolicyA, _mockAsyncInputPolicyB })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockParallelInputPolicyA, _mockParallelInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            // act
            await engine.ProcessAsync(Item);

            // assert
            Received.InOrder(() =>
            {
                _mockAsyncInputPolicyA.ShouldProcessAsync(Item);
                _mockAsyncInputPolicyB.ShouldProcessAsync(Item);
                _mockInputPolicyA.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });

            _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(default);

            await _mockParallelInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
            await _mockParallelInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_C()
        {
            // arrange
            _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Reject);
            _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockAsyncInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));

            var engine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockAsyncInputPolicyA, _mockAsyncInputPolicyB })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockParallelInputPolicyA, _mockParallelInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            // act
            await engine.ProcessAsync(Item);

            // assert
            Received.InOrder(() =>
            {
                _mockAsyncInputPolicyA.ShouldProcessAsync(Item);
                _mockAsyncInputPolicyB.ShouldProcessAsync(Item);
                _mockInputPolicyA.ShouldProcess(Item);
            });

            _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(default);

            await _mockParallelInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
            await _mockParallelInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);

            _mockProcessor.DidNotReceiveWithAnyArgs().Process(default);

            await _mockAsyncProcessor.DidNotReceiveWithAnyArgs().ProcessAsync(default);
            await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);

            _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(default);

            await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_D()
        {
            // arrange
            _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Reject));
            _mockAsyncInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));

            var engine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockAsyncInputPolicyA, _mockAsyncInputPolicyB })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockParallelInputPolicyA, _mockParallelInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            // act
            await engine.ProcessAsync(Item);

            // assert
            Received.InOrder(() => { _mockAsyncInputPolicyA.ShouldProcessAsync(Item); });

            _mockInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcess(default);
            _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(default);

            await _mockAsyncInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);

            await _mockParallelInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
            await _mockParallelInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);

            _mockProcessor.DidNotReceiveWithAnyArgs().Process(default);

            await _mockAsyncProcessor.DidNotReceiveWithAnyArgs().ProcessAsync(default);
            await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);

            _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(default);

            await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_E()
        {
            // arrange
            _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockAsyncInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Reject));
            _mockParallelInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));

            var engine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockAsyncInputPolicyA, _mockAsyncInputPolicyB })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockParallelInputPolicyA, _mockParallelInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            // act
            await engine.ProcessAsync(Item);

            // assert
            Received.InOrder(() =>
            {
                _mockAsyncInputPolicyA.ShouldProcessAsync(Item);
                _mockAsyncInputPolicyB.ShouldProcessAsync(Item);
                _mockInputPolicyA.ShouldProcess(Item);
                _mockInputPolicyB.ShouldProcess(Item);
            });

            await _mockParallelInputPolicyA.Received(1).ShouldProcessAsync(Item);
            await _mockParallelInputPolicyB.Received(1).ShouldProcessAsync(Item);

            _mockProcessor.DidNotReceiveWithAnyArgs().Process(default);

            await _mockAsyncProcessor.DidNotReceiveWithAnyArgs().ProcessAsync(default);
            await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);

            _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(default);

            await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_F()
        {
            // arrange
            _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockAsyncInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Accept));
            _mockParallelInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));

            var engine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockAsyncInputPolicyA, _mockAsyncInputPolicyB })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockParallelInputPolicyA, _mockParallelInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            // act
            await engine.ProcessAsync(Item);

            // assert
            Received.InOrder(() =>
            {
                _mockAsyncInputPolicyA.ShouldProcessAsync(Item);
                _mockAsyncInputPolicyB.ShouldProcessAsync(Item);
                _mockInputPolicyA.ShouldProcess(Item);
                _mockInputPolicyB.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });

            await _mockParallelInputPolicyA.Received(1).ShouldProcessAsync(Item);
            await _mockParallelInputPolicyB.Received(1).ShouldProcessAsync(Item);
        }

        [Test]
        public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_G()
        {
            // arrange
            _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Accept));
            _mockAsyncInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Accept));
            _mockParallelInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
                .Returns(Task.FromResult(InputPolicyResult.Continue));

            var engine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockAsyncInputPolicyA, _mockAsyncInputPolicyB })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockParallelInputPolicyA, _mockParallelInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            // act
            await engine.ProcessAsync(Item);

            // assert
            Received.InOrder(() =>
            {
                _mockAsyncInputPolicyA.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });

            _mockInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcess(default);
            _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(default);

            await _mockAsyncInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);

            await _mockParallelInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
            await _mockParallelInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
        }
    }
}