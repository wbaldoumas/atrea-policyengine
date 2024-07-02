using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Atrea.PolicyEngine.Tests.Engines;

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

#nullable disable
    private IInputPolicy<int> _mockInputPolicyA;
    private IInputPolicy<int> _mockInputPolicyB;
    private IProcessor<int> _mockProcessor;
    private IOutputPolicy<int> _mockOutputPolicy;
#nullable restore

    [Test]
    public void Exception_Thrown_When_Invalid_InputPolicyResult_Is_Returned()
    {
        Assert.That(Enum.IsDefined(typeof(InputPolicyResult), int.MaxValue), Is.False);
        const InputPolicyResult badInputPolicyResult = (InputPolicyResult)int.MaxValue;

        _mockInputPolicyA.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
        _mockInputPolicyB.ShouldProcess(Item).Returns(badInputPolicyResult);

        var policyEngine = PolicyEngineBuilder<int>
            .Configure()
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithOutputPolicies(_mockOutputPolicy)
            .Build();

        var act = () => policyEngine.Process(Item);

        act.Should().Throw<ArgumentOutOfRangeException>();

        Received.InOrder(() =>
        {
            _mockInputPolicyA.ShouldProcess(Item);
            _mockInputPolicyB.ShouldProcess(Item);
        });

        _mockProcessor.DidNotReceiveWithAnyArgs().Process(Arg.Any<int>());
        _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(Arg.Any<int>());
    }

    [Test]
    public void Policy_Engine_Runs_Expected_Components_A()
    {
        _mockInputPolicyA.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
        _mockInputPolicyB.ShouldProcess(Item).Returns(InputPolicyResult.Continue);

        var policyEngine = PolicyEngineBuilder<int>
            .Configure()
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithOutputPolicies(_mockOutputPolicy)
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
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithOutputPolicies(_mockOutputPolicy)
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
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithOutputPolicies(_mockOutputPolicy)
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
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithOutputPolicies(_mockOutputPolicy)
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
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithOutputPolicies(_mockOutputPolicy)
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
            .WithProcessors(_mockProcessor)
            .WithOutputPolicies(_mockOutputPolicy)
            .Build();

        policyEngine.Process(Item);

        Received.InOrder(() =>
        {
            _mockProcessor.Process(Item);
            _mockOutputPolicy.Apply(Item);
        });
    }

    [Test]
    public void Policy_Engine_Runs_Expected_Components_With_Multiple_Items()
    {
        _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
        _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);

        var policyEngine = PolicyEngineBuilder<int>
            .Configure()
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithOutputPolicies(_mockOutputPolicy)
            .Build();

        const int item1 = 1;
        const int item2 = 2;

        policyEngine.Process(new List<int> { item1, item2 });

        Received.InOrder(() =>
        {
            _mockInputPolicyA.ShouldProcess(item1);
            _mockInputPolicyB.ShouldProcess(item1);
            _mockProcessor.Process(item1);
            _mockOutputPolicy.Apply(item1);

            _mockInputPolicyA.ShouldProcess(item2);
            _mockInputPolicyB.ShouldProcess(item2);
            _mockProcessor.Process(item2);
            _mockOutputPolicy.Apply(item2);
        });
    }
}