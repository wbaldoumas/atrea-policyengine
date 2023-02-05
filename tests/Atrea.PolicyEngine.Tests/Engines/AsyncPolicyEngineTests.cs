using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Tests.Engines;

[TestFixture]
public class AsyncPolicyEngineTests
{
    private const int Item = 1;

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

#nullable disable
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
#nullable restore

    [Test]
    public async Task Exception_Thrown_When_Invalid_InputPolicyResult_Is_Returned_A()
    {
        // arrange
        Assert.IsFalse(Enum.IsDefined(typeof(InputPolicyResult), int.MaxValue));
        const InputPolicyResult badInputPolicyResult = (InputPolicyResult)int.MaxValue;

        _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
        _mockInputPolicyB.ShouldProcess(Arg.Any<int>()).Returns(InputPolicyResult.Continue);
        _mockAsyncInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
            .Returns(Task.FromResult(badInputPolicyResult));
        _mockAsyncInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
            .Returns(Task.FromResult(InputPolicyResult.Continue));
        _mockParallelInputPolicyA.ShouldProcessAsync(Arg.Any<int>())
            .Returns(Task.FromResult(InputPolicyResult.Continue));
        _mockParallelInputPolicyB.ShouldProcessAsync(Arg.Any<int>())
            .Returns(Task.FromResult(InputPolicyResult.Continue));

        var engine = AsyncPolicyEngineBuilder<int>.Configure()
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
            .Build();

        // act
        Func<Task> act = async () => await engine.ProcessAsync(Item);

        await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

        // assert
        Received.InOrder(() => { _mockAsyncInputPolicyA.ShouldProcessAsync(Item); });

        _mockInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcess(default);
        _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(default);

        await _mockAsyncInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);

        await _mockParallelInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
        await _mockParallelInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);

        _mockProcessor.DidNotReceiveWithAnyArgs().Process(Arg.Any<int>());

        await _mockAsyncProcessor.DidNotReceiveWithAnyArgs().ProcessAsync(default);
        await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);

        _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(default);

        await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);
    }

    [Test]
    public async Task Exception_Thrown_When_Invalid_InputPolicyResult_Is_Returned_B()
    {
        // arrange
        Assert.IsFalse(Enum.IsDefined(typeof(InputPolicyResult), int.MaxValue));
        const InputPolicyResult badInputPolicyResult = (InputPolicyResult)int.MaxValue;

        _mockInputPolicyA.ShouldProcess(Arg.Any<int>()).Returns(badInputPolicyResult);
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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
            .Build();

        // act
        Func<Task> act = async () => await engine.ProcessAsync(Item);

        await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

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

        _mockProcessor.DidNotReceiveWithAnyArgs().Process(Arg.Any<int>());

        await _mockAsyncProcessor.DidNotReceiveWithAnyArgs().ProcessAsync(default);
        await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);

        _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(default);

        await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);
    }

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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
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

        _mockProcessor.DidNotReceiveWithAnyArgs().Process(Arg.Any<int>());

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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
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

        _mockProcessor.DidNotReceiveWithAnyArgs().Process(Arg.Any<int>());

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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
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

        _mockProcessor.DidNotReceiveWithAnyArgs().Process(Arg.Any<int>());

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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
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

    [Test]
    public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_With_Multiple_Items()
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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
            .Build();

        const int item1 = 1;
        const int item2 = 2;

        // act
        await engine.ProcessAsync(new List<int> { item1, item2 });

        // assert
        Received.InOrder(() =>
        {
            _mockAsyncInputPolicyA.ShouldProcessAsync(item1);
            _mockProcessor.Process(item1);
            _mockAsyncProcessor.ProcessAsync(item1);
            _mockAsyncOutputPolicy.ApplyAsync(item1);
            _mockOutputPolicy.Apply(item1);

            _mockAsyncInputPolicyA.ShouldProcessAsync(item2);
            _mockProcessor.Process(item2);
            _mockAsyncProcessor.ProcessAsync(item2);
            _mockAsyncOutputPolicy.ApplyAsync(item2);
            _mockOutputPolicy.Apply(item2);
        });

        _mockInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcess(default);
        _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(default);

        await _mockAsyncInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);

        await _mockParallelInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
        await _mockParallelInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
    }

    [Test]
    public async Task Fully_Configured_AsyncPolicyEngine_Runs_Components_In_Expected_Order_With_Parallel_Items()
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
            .WithAsyncInputPolicies(_mockAsyncInputPolicyA, _mockAsyncInputPolicyB)
            .WithInputPolicies(_mockInputPolicyA, _mockInputPolicyB)
            .WithParallelInputPolicies(_mockParallelInputPolicyA, _mockParallelInputPolicyB)
            .WithProcessors(_mockProcessor)
            .WithAsyncProcessors(_mockAsyncProcessor)
            .WithAsyncOutputPolicies(_mockAsyncOutputPolicy)
            .WithOutputPolicies(_mockOutputPolicy)
            .Build();

        const int item1 = 1;
        const int item2 = 2;

        // act
        await engine.ProcessParallelAsync(new List<int> { item1, item2 });

        // assert
        await _mockAsyncInputPolicyA.Received(1).ShouldProcessAsync(item1);
        _mockProcessor.Received(1).Process(item1);
        await _mockAsyncProcessor.Received(1).ProcessAsync(item1);
        await _mockAsyncOutputPolicy.Received(1).ApplyAsync(item1);
        _mockOutputPolicy.Received(1).Apply(item1);

        await _mockAsyncInputPolicyA.Received(1).ShouldProcessAsync(item2);
        _mockProcessor.Received(1).Process(item2);
        await _mockAsyncProcessor.Received(1).ProcessAsync(item2);
        await _mockAsyncOutputPolicy.Received(1).ApplyAsync(item2);
        _mockOutputPolicy.Received(1).Apply(item2);

        _mockInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcess(default);
        _mockInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcess(default);

        await _mockAsyncInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);

        await _mockParallelInputPolicyA.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
        await _mockParallelInputPolicyB.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
    }
}