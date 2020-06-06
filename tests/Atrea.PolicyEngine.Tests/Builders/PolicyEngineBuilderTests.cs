using System.Collections.Generic;
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
        private const int Item = 1;

        [Test]
        public void Fully_Configured_Policy_Engine_Runs_All_Components()
        {
            var mockInputPolicyA = Substitute.For<IInputPolicy<int>>();
            var mockInputPolicyB = Substitute.For<IInputPolicy<int>>();

            mockInputPolicyA.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
            mockInputPolicyB.ShouldProcess(Item).Returns(InputPolicyResult.Continue);

            var mockProcessorA = Substitute.For<IProcessor<int>>();
            var mockProcessorB = Substitute.For<IProcessor<int>>();

            var mockOutputPolicyA = Substitute.For<IOutputPolicy<int>>();
            var mockOutputPolicyB = Substitute.For<IOutputPolicy<int>>();

            var policyEngine = PolicyEngineBuilder<int>
                .Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { mockInputPolicyA, mockInputPolicyB })
                .WithProcessors(new List<IProcessor<int>> { mockProcessorA, mockProcessorB })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { mockOutputPolicyA, mockOutputPolicyB })
                .Build();

            policyEngine.Process(1);

            Received.InOrder(() =>
                {
                    mockInputPolicyA.ShouldProcess(Item);
                    mockInputPolicyB.ShouldProcess(Item);
                    mockProcessorA.Process(Item);
                    mockProcessorB.Process(Item);
                    mockOutputPolicyA.Apply(Item);
                    mockOutputPolicyB.Apply(Item);
                }
            );
        }
    }
}