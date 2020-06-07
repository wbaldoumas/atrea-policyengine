using System.Collections.Generic;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Engines
{
    [TestFixture]
    public class PolicyEngineTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockInputPolicyA = Substitute.For<IInputPolicy<int>>();
            _mockInputPolicyB = Substitute.For<IInputPolicy<int>>();
            _mockProcessor = Substitute.For<IProcessor<int>>();
            _mockOutputPolicy = Substitute.For<IOutputPolicy<int>>();
        }

        private const int Item = 1;

        private IInputPolicy<int> _mockInputPolicyA;
        private IInputPolicy<int> _mockInputPolicyB;
        private IProcessor<int> _mockProcessor;
        private IOutputPolicy<int> _mockOutputPolicy;

        [Test]
        public void Policy_Engine_Runs_Expected_Components_A()
        {
            _mockInputPolicyA.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
            _mockInputPolicyB.ShouldProcess(Item).Returns(InputPolicyResult.Continue);

            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicyA.ShouldProcess(Item);
                _mockInputPolicyB.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public void Policy_Engine_Runs_Expected_Components_B()
        {
            _mockInputPolicyA.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
            _mockInputPolicyB.ShouldProcess(Item).Returns(InputPolicyResult.Accept);

            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicyA.ShouldProcess(Item);
                _mockInputPolicyB.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public void Policy_Engine_Runs_Expected_Components_C()
        {
            _mockInputPolicyA.ShouldProcess(Item).Returns(InputPolicyResult.Accept);
            _mockInputPolicyB.ShouldProcess(Item).Returns(InputPolicyResult.Reject);

            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicyA.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
            });

            _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(Arg.Any<int>());
        }

        [Test]
        public void Policy_Engine_Runs_Expected_Components_D()
        {
            _mockInputPolicyA.ShouldProcess(Item).Returns(InputPolicyResult.Reject);
            _mockInputPolicyB.ShouldProcess(Item).Returns(InputPolicyResult.Continue);

            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() => { _mockInputPolicyA.ShouldProcess(Item); });

            _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(Arg.Any<int>());
            _mockProcessor.DidNotReceiveWithAnyArgs().Process(Arg.Any<int>());
            _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(Arg.Any<int>());
        }

        [Test]
        public void Policy_Engine_Runs_Expected_Components_E()
        {
            _mockInputPolicyA.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
            _mockInputPolicyB.ShouldProcess(Item).Returns(InputPolicyResult.Reject);

            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicyA, _mockInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicyA.ShouldProcess(Item);
                _mockInputPolicyB.ShouldProcess(Item);
            });

            _mockProcessor.DidNotReceiveWithAnyArgs().Process(Arg.Any<int>());
            _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(Arg.Any<int>());
        }

        [Test]
        public void Policy_Engine_Runs_Expected_Components_F()
        {
            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }
    }
}