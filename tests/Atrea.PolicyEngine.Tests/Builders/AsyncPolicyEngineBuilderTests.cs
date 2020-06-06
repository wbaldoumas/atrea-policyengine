using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Builders
{
    public class AsyncPolicyEngineBuilderTests
    {
        private const int Item = 1;
        private IAsyncInputPolicy<int> _mockAsyncInputPolicy;
        private IAsyncOutputPolicy<int> _mockAsyncOutputPolicy;
        private IAsyncProcessor<int> _mockAsyncProcessor;

        private IInputPolicy<int> _mockInputPolicy;
        private IOutputPolicy<int> _mockOutputPolicy;
        private IAsyncInputPolicy<int> _mockParallelInputPolicy;
        private IAsyncOutputPolicy<int> _mockParallelOutputPolicy;
        private IAsyncProcessor<int> _mockParallelProcessor;
        private IProcessor<int> _mockProcessor;

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
        public async Task AsyncPolicyEngineBuilder_Configuration_105()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_106()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_107()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_108()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_109()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_110()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_111()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_112()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_113()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_114()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_115()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_116()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_117()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_118()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_119()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_120()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_121()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_122()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_123()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_124()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_125()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_126()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_127()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_128()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_129()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_130()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_131()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_132()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_133()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_134()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_135()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_136()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_137()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_138()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_139()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_140()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_141()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_142()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_143()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_144()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_145()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_146()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_147()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_148()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_149()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_150()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_151()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_152()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_153()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_154()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_155()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_156()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_157()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_158()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_159()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_160()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_161()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_162()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_163()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_164()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_165()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_166()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_167()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_168()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_169()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_170()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_171()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_172()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_173()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_174()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_175()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_176()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_177()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_178()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_179()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_180()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_181()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_182()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_183()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_184()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_185()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_186()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_187()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_188()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_189()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_190()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_191()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_192()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_193()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_194()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_195()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_196()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_197()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_198()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_199()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_200()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_201()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_202()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_203()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_204()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_205()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_206()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_207()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_208()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_209()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_210()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_211()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_212()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_213()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_214()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_215()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_216()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_217()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_218()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_219()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_220()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_221()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_222()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_223()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_224()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_225()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_226()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_227()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_228()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_229()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_230()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_231()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_232()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_233()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_234()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_235()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_236()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_237()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_238()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_239()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_240()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_241()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_242()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_243()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_244()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_245()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_246()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_247()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_248()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_249()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_250()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_251()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_252()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_253()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_254()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_255()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_256()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_257()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_258()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_259()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_260()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_261()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_262()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_263()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_264()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_265()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_266()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_267()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_268()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_269()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_270()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_271()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_272()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_273()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_274()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_275()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_276()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_277()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_278()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_279()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_280()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_281()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_282()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_283()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_284()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_285()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_286()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_287()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_288()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_289()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_290()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_291()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_292()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_293()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_294()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_295()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_296()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_297()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_298()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_299()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_300()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_301()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_302()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_303()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_304()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_305()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_306()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_307()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_308()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_309()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_310()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_311()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_312()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_313()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_314()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_315()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_316()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_317()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_318()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_319()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_320()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_321()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_322()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_323()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_324()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_325()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_326()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_327()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_328()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_329()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_330()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_331()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_332()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_333()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_334()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_335()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_336()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_337()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_338()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_339()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_340()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_341()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_342()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_343()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_344()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_345()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_346()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_347()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_348()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_349()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_350()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_351()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_352()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_353()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_354()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_355()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_356()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_357()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_358()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_359()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_360()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_361()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_362()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_363()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_364()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_365()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_366()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_367()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_368()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_369()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_370()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_371()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_372()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_373()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_374()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_375()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_376()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_377()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_378()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_379()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_380()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_381()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_382()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_383()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_384()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_385()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_386()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_387()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_388()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_389()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_390()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_391()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_392()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_393()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_394()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_395()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_396()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_397()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_398()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_399()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_400()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_401()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_402()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_403()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_404()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_405()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_406()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_407()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_408()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_409()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_410()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_411()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_412()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_413()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_414()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_415()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_416()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_417()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_418()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_419()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_420()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_421()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_422()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_423()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_424()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_425()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_426()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_427()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_428()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_429()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_430()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_431()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_432()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_433()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_434()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_435()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_436()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_437()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_438()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_439()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_440()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_441()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_442()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_443()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_444()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_445()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_446()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_447()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_448()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_449()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_450()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_451()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_452()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_453()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_454()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_455()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_456()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_457()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_458()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_459()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_460()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_461()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_462()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_463()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_464()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_465()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_466()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_467()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_468()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_469()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_470()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_471()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_472()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_473()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_474()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_475()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_476()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_477()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_478()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_479()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_480()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_481()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_482()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_483()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_484()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_485()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_486()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_487()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_488()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_489()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_490()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_491()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_492()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_493()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_494()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_495()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_496()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_497()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_498()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_499()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_500()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_501()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_502()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_503()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_504()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_505()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_506()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_507()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_508()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_509()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_510()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_511()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_512()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_513()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_514()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_515()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_516()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_517()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_518()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_519()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_520()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_521()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_522()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_523()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_524()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_525()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_526()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_527()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_528()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_529()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_530()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_531()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_532()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_533()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_534()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_535()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_536()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_537()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_538()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_539()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_540()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_541()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_542()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_543()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_544()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_545()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_546()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_547()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_548()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_549()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_550()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_551()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_552()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_553()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_554()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_555()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_556()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_557()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_558()
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
        public async Task AsyncPolicyEngineBuilder_Configuration_559()
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
    }
}