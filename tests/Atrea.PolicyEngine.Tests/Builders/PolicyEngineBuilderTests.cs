using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Atrea.PolicyEngine.Tests.Builders
{
    [TestFixture]
    public class PolicyEngineBuilderTests
    {
        private const int Item = 1;

        private IInputPolicy<int> _mockInputPolicy;
        private IProcessor<int> _mockProcessor;
        private IOutputPolicy<int> _mockOutputPolicy;

        [SetUp]
        public void SetUp()
        {
            _mockInputPolicy = Substitute.For<IInputPolicy<int>>();
            _mockProcessor = Substitute.For<IProcessor<int>>();
            _mockOutputPolicy = Substitute.For<IOutputPolicy<int>>();

            _mockInputPolicy.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
        }

        [Test]
        public void Fully_Configured_Policy_Engine_Runs_All_Components()
        {
            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
                {
                    _mockInputPolicy.ShouldProcess(Item);
                    _mockProcessor.Process(Item);
                    _mockOutputPolicy.Apply(Item);
                }
            );
        }

        [Test]
        public void Policy_Engine_Configured_Without_Input_Policies_Runs_Configured_Components()
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
                }
            );
        }

        [Test]
        public void Policy_Engine_Configured_Without_Processors_Runs_Configured_Components()
        {
            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
                {
                    _mockInputPolicy.ShouldProcess(Item);
                    _mockOutputPolicy.Apply(Item);
                }
            );
        }

        [Test]
        public void Policy_Engine_Configured_Without_Output_Policies_Runs_Configured_Components()
        {
            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
                {
                    _mockInputPolicy.ShouldProcess(Item);
                    _mockProcessor.Process(Item);
                }
            );
        }
    }
}