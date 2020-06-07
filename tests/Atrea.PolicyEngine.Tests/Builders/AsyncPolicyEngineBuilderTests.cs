﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Builders
{
    [TestFixture]
    public class AsyncPolicyEngineBuilderTests
    {
        private const int Item = 1;

        private IInputPolicy<int> _mockInputPolicy;
        private IAsyncInputPolicy<int> _mockAsyncInputPolicy;
        private IAsyncInputPolicy<int> _mockParallelInputPolicy;

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
            _mockParallelInputPolicy = Substitute.For<IAsyncInputPolicy<int>>();

            _mockInputPolicy.ShouldProcess(Item).Returns(InputPolicyResult.Continue);
            _mockAsyncInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(InputPolicyResult.Continue));
            _mockParallelInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(InputPolicyResult.Continue));

            _mockProcessor = Substitute.For<IProcessor<int>>();
            _mockAsyncProcessor = Substitute.For<IAsyncProcessor<int>>();
            _mockParallelProcessor = Substitute.For<IAsyncProcessor<int>>();

            _mockOutputPolicy = Substitute.For<IOutputPolicy<int>>();
            _mockAsyncOutputPolicy = Substitute.For<IAsyncOutputPolicy<int>>();
            _mockParallelOutputPolicy = Substitute.For<IAsyncOutputPolicy<int>>();
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_0()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_1()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_2()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_3()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_4()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_5()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_6()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_7()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_8()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_9()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_10()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_11()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_12()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_13()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_14()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_15()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_16()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_17()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_18()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_19()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_20()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_21()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_22()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_23()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_24()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_25()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_26()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_27()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_28()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_29()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_30()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_31()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_32()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
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
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_33()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_34()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_35()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_36()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_37()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_38()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_39()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_40()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_41()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_42()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
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
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_43()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_44()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_45()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_46()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_47()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_48()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_49()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_50()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_51()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_52()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_53()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_54()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_55()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_56()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_57()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_58()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_59()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_60()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_61()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_62()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_63()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_64()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_65()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_66()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
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
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_67()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_68()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_69()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_70()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_71()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_72()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_73()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_74()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_75()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_76()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_77()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_78()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_79()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_80()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_81()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_82()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_83()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_84()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_85()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_86()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_87()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_88()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_89()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_90()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_91()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_92()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_93()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_94()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_95()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_96()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_97()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_98()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_99()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_100()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_101()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_102()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_103()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_104()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_105()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_106()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_107()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_108()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_109()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_110()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_111()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_112()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_113()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_114()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_115()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_116()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_117()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_118()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_119()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_120()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
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
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_121()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_122()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_123()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_124()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_125()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_126()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_127()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_128()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_129()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_130()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_131()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_132()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_133()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_134()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_135()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_136()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_137()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_138()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_139()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_140()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_141()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_142()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_143()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_144()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
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
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_145()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
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
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_146()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_147()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_148()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_149()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_150()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_151()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_152()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_153()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_154()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_155()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_156()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_157()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_158()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_159()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_160()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_161()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_162()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_163()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_164()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_165()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_166()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_167()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_168()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_169()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_170()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_171()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_172()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_173()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_174()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_175()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_176()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_177()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_178()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_179()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_180()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_181()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_182()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_183()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_184()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_185()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_186()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_187()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_188()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_189()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_190()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_191()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_192()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_193()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_194()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_195()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_196()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_197()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_198()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_199()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_200()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_201()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_202()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_203()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_204()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_205()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_206()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_207()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_208()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_209()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_210()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_211()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_212()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_213()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_214()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_215()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_216()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_217()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_218()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_219()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_220()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_221()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_222()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_223()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_224()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_225()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_226()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_227()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_228()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_229()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_230()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_231()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_232()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_233()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_234()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_235()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
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
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_236()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
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
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_237()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_238()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_239()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
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
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_240()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_241()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
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
        public async Task AsyncPolicyEngine_Runs_Configured_Components_242()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_243()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_244()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_245()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_246()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_247()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_248()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_249()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_250()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_251()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_252()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_253()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_254()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_255()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_256()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_257()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_258()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_259()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_260()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_261()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_262()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_263()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_264()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_265()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
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
        public async Task AsyncPolicyEngine_Runs_Configured_Components_266()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_267()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_268()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_269()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_270()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
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
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_271()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_272()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_273()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
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
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_274()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_275()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
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
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_276()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_277()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_278()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_279()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_280()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_281()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_282()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_283()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_284()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_285()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_286()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_287()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_288()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_289()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_290()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_291()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_292()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_293()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_294()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_295()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_296()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_297()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_298()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_299()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_300()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_301()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_302()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_303()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_304()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_305()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_306()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_307()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_308()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_309()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_310()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_311()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_312()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_313()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_314()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_315()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_316()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_317()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_318()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_319()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_320()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_321()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_322()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_323()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_324()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_325()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_326()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_327()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_328()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_329()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_330()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_331()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_332()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_333()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_334()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_335()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_336()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_337()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_338()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_339()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
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
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_340()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_341()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_342()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_343()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_344()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_345()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_346()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_347()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
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
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_348()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_349()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_350()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_351()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_352()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_353()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_354()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_355()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
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
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_356()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_357()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
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
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_358()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_359()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_360()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_361()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_362()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_363()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_364()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_365()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_366()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_367()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_368()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_369()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_370()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
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
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_371()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_372()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_373()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_374()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_375()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_376()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_377()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_378()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_379()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_380()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_381()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_382()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_383()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_384()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_385()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_386()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_387()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_388()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_389()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_390()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_391()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_392()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_393()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_394()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_395()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_396()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_397()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_398()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_399()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_400()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_401()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_402()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_403()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_404()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_405()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_406()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_407()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_408()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_409()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_410()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_411()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_412()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_413()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_414()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_415()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_416()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_417()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_418()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_419()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_420()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_421()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_422()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_423()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_424()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_425()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_426()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_427()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_428()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_429()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_430()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_431()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_432()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_433()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_434()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_435()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_436()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_437()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_438()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_439()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_440()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_441()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_442()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_443()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_444()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_445()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_446()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_447()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_448()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_449()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_450()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_451()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_452()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
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
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_453()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_454()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_0()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_1()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_2()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_3()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_4()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_5()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_6()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_7()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_8()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_9()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_10()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_11()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_12()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_13()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_14()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_15()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_16()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_17()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_18()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_19()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_20()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_21()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_22()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_23()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_24()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_25()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_26()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_27()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_28()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_29()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_30()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_31()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_32()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_33()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_34()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_35()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_36()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_37()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_38()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_39()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_40()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_41()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_42()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_43()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_44()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_45()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_46()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_47()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_48()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_49()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_50()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_51()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_52()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_53()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_54()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_55()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_56()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_57()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_58()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_59()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_60()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_61()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_62()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_63()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_64()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_65()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_66()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_67()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_68()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_69()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_70()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_71()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_72()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_73()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_74()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_75()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_76()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_77()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_78()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_79()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_80()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_81()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_82()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_83()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_84()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_85()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_86()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_87()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_88()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_89()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_90()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_91()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_92()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_93()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_94()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_95()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_96()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_97()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_98()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_99()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_100()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_101()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_102()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_103()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_104()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_0()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_1()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_2()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_3()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_4()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_5()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_6()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_7()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_8()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_9()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_10()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_11()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_12()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_13()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_14()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_15()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_16()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_17()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_18()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_19()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_20()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_21()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_22()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_23()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_24()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_25()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_26()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_27()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_28()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_29()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_30()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_31()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_32()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_33()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_34()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_35()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_36()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_37()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_38()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_39()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_40()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_41()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_42()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_43()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_44()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_45()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_46()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_47()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_48()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_49()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_50()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_51()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_52()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_53()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_54()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_55()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_56()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_57()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_58()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_59()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_60()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_61()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_62()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_63()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_64()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_65()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_66()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_67()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_68()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_69()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_70()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_71()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_72()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_73()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_74()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_75()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_76()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_77()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_78()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_79()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_80()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_81()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_82()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_83()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_84()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_85()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_86()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_87()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_88()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_89()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_90()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_91()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_92()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_93()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_94()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_95()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_96()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_97()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_98()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_99()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_100()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_101()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_102()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_103()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_104()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_0()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_1()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_2()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_3()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_4()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_5()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_6()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_7()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_8()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_9()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_10()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_11()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_12()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_13()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_14()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_15()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_16()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_17()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_18()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_19()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_20()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_21()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_22()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_23()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_24()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_25()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_26()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_27()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_28()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_29()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_30()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_31()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_32()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_33()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_34()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_35()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_36()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_37()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_38()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_39()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_40()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_41()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_42()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_43()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_44()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_45()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_46()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_47()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_48()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_49()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_50()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_51()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_52()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_53()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_54()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_55()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_56()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_57()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_58()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_59()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_60()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_61()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_62()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_63()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_64()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_65()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_66()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_67()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_68()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_69()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_70()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_71()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_72()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_73()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_74()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_75()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_76()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_77()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_78()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_79()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_80()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_81()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_82()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_83()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_84()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_85()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_86()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_87()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_88()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_89()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_90()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_91()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_92()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_93()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_94()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_95()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_96()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_97()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_98()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_99()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_100()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_101()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_102()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_103()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Output_Policies_104()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_0()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockOutputPolicy.Apply(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_1()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockAsyncOutputPolicy.ApplyAsync(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_2()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockParallelOutputPolicy.ApplyAsync(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_3()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_4()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_5()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_6()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_7()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_8()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_9()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_10()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_11()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_12()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_13()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Policies_Or_Processors_14()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithParallelOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockParallelOutputPolicy })
                .WithAsyncOutputPolicies(new List<IAsyncOutputPolicy<int>> { _mockAsyncOutputPolicy })
                .WithOutputPolicies(new List<IOutputPolicy<int>> { _mockOutputPolicy })
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelOutputPolicy.ApplyAsync(Item);
                _mockAsyncOutputPolicy.ApplyAsync(Item);
                _mockOutputPolicy.Apply(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_0()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockProcessor.Process(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_1()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockAsyncProcessor.ProcessAsync(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_2()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockParallelProcessor.ProcessAsync(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_3()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_4()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_5()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_6()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_7()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_8()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_9()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_10()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_11()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockParallelProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_12()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_13()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Input_Or_Output_Policies_14()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithParallelProcessors(new List<IAsyncProcessor<int>> { _mockParallelProcessor })
                .WithAsyncProcessors(new List<IAsyncProcessor<int>> { _mockAsyncProcessor })
                .WithProcessors(new List<IProcessor<int>> { _mockProcessor })
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelProcessor.ProcessAsync(Item);
                _mockAsyncProcessor.ProcessAsync(Item);
                _mockProcessor.Process(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_0()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockInputPolicy.ShouldProcess(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_1()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockAsyncInputPolicy.ShouldProcessAsync(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_2()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() => { _mockParallelInputPolicy.ShouldProcessAsync(Item); });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_3()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_4()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_5()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_6()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_7()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_8()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_9()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_10()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_11()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_12()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_13()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Configured_Components_Without_Processors_Or_Output_Policies_14()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithParallelInputPolicies(new List<IAsyncInputPolicy<int>> { _mockParallelInputPolicy })
                .WithAsyncInputPolicies(new List<IAsyncInputPolicy<int>> { _mockAsyncInputPolicy })
                .WithInputPolicies(new List<IInputPolicy<int>> { _mockInputPolicy })
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            Received.InOrder(() =>
            {
                _mockParallelInputPolicy.ShouldProcessAsync(Item);
                _mockAsyncInputPolicy.ShouldProcessAsync(Item);
                _mockInputPolicy.ShouldProcess(Item);
            });
        }

        [Test]
        public async Task AsyncPolicyEngine_Runs_Without_Configuring_Any_Components()
        {
            var asyncPolicyEngine = AsyncPolicyEngineBuilder<int>.Configure()
                .WithoutInputPolicies()
                .WithoutProcessors()
                .WithoutOutputPolicies()
                .Build();

            await asyncPolicyEngine.ProcessAsync(Item);

            _mockInputPolicy.DidNotReceiveWithAnyArgs().ShouldProcess(default);
            _mockProcessor.DidNotReceiveWithAnyArgs().Process(default);
            _mockOutputPolicy.DidNotReceiveWithAnyArgs().Apply(default);

            await _mockAsyncInputPolicy.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
            await _mockAsyncProcessor.DidNotReceiveWithAnyArgs().ProcessAsync(default);
            await _mockAsyncOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);

            await _mockParallelInputPolicy.DidNotReceiveWithAnyArgs().ShouldProcessAsync(default);
            await _mockParallelProcessor.DidNotReceiveWithAnyArgs().ProcessAsync(default);
            await _mockParallelOutputPolicy.DidNotReceiveWithAnyArgs().ApplyAsync(default);
        }
    }
}