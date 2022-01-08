using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Builders
{
    [TestFixture]
    public class PolicyEngineBuilderTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockInputPolicy = Substitute.For<IInputPolicy<int>>();
            _mockProcessor = Substitute.For<IProcessor<int>>();
            _mockOutputPolicy = Substitute.For<IOutputPolicy<int>>();

            _mockInputPolicy.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
        }

        private const int Item = 1;

#nullable disable
        private IInputPolicy<int> _mockInputPolicy;
        private IProcessor<int> _mockProcessor;
        private IOutputPolicy<int> _mockOutputPolicy;
#nullable restore

        [Test]
        public void Fully_Configured_Policy_Engine_Runs_All_Components()
        {
            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(_mockInputPolicy)
                .WithProcessors(_mockProcessor)
                .WithOutputPolicies(_mockOutputPolicy)
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
                .WithProcessors(_mockProcessor)
                .WithOutputPolicies(_mockOutputPolicy)
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
        public void Policy_Engine_Configured_Without_Output_Policies_Runs_Configured_Components()
        {
            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(_mockInputPolicy)
                .WithProcessors(_mockProcessor)
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

        [Test]
        public void Policy_Engine_Configured_Without_Processors_Runs_Configured_Components()
        {
            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(_mockInputPolicy)
                .WithoutProcessors()
                .WithOutputPolicies(_mockOutputPolicy)
                .Build();

            policyEngine.Process(Item);

            Received.InOrder(() =>
                {
                    _mockInputPolicy.ShouldProcess(Item);
                    _mockOutputPolicy.Apply(Item);
                }
            );
        }
    }
}