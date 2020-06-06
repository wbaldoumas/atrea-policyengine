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

            var engine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>>
                    { _mockAsyncInputPolicyA, _mockAsyncInputPolicyB })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
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
        }
    }
}