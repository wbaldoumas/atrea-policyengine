using Atrea.PolicyEngine.Internal.PolicyRunners.Input;
using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Tests.PolicyRunners
{
    [TestFixture]
    public class AsyncInputPolicyRunnerDecoratorTests
    {
#nullable disable
        private IAsyncInputPolicyRunner<int> _mockInnerAsyncInputPolicyRunner;
#nullable restore

        [SetUp]
        public void SetUp()
        {
            _mockInnerAsyncInputPolicyRunner = Substitute.For<IAsyncInputPolicyRunner<int>>();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public async Task AsyncInputPolicyRunnerDecorator_returns_expected_results(
            InputPolicyResult innerInputPolicyResult,
            InputPolicyResult expectedInputPolicyResult)
        {
            // arrange
            var mockInputPolicy = Substitute.For<IAsyncInputPolicy<int>>();

            mockInputPolicy.ShouldProcessAsync(Arg.Any<int>()).Returns(expectedInputPolicyResult);
            _mockInnerAsyncInputPolicyRunner.ShouldProcessAsync(Arg.Any<int>()).Returns(innerInputPolicyResult);

            var asyncInputPolicyRunnerDecorator = new AsyncInputPolicyRunnerDecorator<int>(
                _mockInnerAsyncInputPolicyRunner,
                new List<IAsyncInputPolicy<int>> { mockInputPolicy }
            );

            // act
            var inputPolicyResult = await asyncInputPolicyRunnerDecorator.ShouldProcessAsync(1);

            // assert
            inputPolicyResult.Should().Be(expectedInputPolicyResult);
        }

        [Test]
        public async Task When_inner_input_policy_result_is_invalid_ArgumentOutOfRangeException_is_thrown()
        {
            // arrange
            _mockInnerAsyncInputPolicyRunner
                .ShouldProcessAsync(Arg.Any<int>())
                .Returns((InputPolicyResult)(-1));

            var asyncInputPolicyRunnerDecorator = new AsyncInputPolicyRunnerDecorator<int>(
                _mockInnerAsyncInputPolicyRunner,
                new List<IAsyncInputPolicy<int>>()
            );

            // act
            Func<Task> act = async () => await asyncInputPolicyRunnerDecorator.ShouldProcessAsync(1);

            // assert
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }

        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(
                    InputPolicyResult.Accept,
                    InputPolicyResult.Accept
                ).SetName(
                    $"When inner policy runner results in {InputPolicyResult.Accept}, {InputPolicyResult.Accept} is returned.");

                yield return new TestCaseData(
                    InputPolicyResult.Reject,
                    InputPolicyResult.Reject
                ).SetName(
                    $"When inner policy runner results in {InputPolicyResult.Reject}, {InputPolicyResult.Reject} is returned.");

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Accept
                ).SetName($"When inner policy runner results in {InputPolicyResult.Continue}, {InputPolicyResult.Accept} is returned when input policies accept.");

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Reject
                ).SetName($"When inner policy runner results in {InputPolicyResult.Continue}, {InputPolicyResult.Reject} is returned when input policies reject.");

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue
                ).SetName($"When inner policy runner results in {InputPolicyResult.Continue}, {InputPolicyResult.Continue} is returned when input policies continue.");
            }
        }
    }
}
