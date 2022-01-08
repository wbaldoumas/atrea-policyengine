using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    [TestFixture]
    public class AsyncOrTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockLeftInputPolicy = Substitute.For<IAsyncInputPolicy<int>>();
            _mockRightInputPolicy = Substitute.For<IAsyncInputPolicy<int>>();
        }

        private const int Item = 1;

#nullable disable
        private IAsyncInputPolicy<int> _mockLeftInputPolicy;
        private IAsyncInputPolicy<int> _mockRightInputPolicy;
#nullable restore

        private static readonly IEnumerable<TestCaseData> TestCases = CompoundBooleanInputPolicyTestCases.OrTestCases;

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public async Task Extension_Constructed_Or_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(leftReturn));
            _mockRightInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(rightReturn));

            var or = _mockLeftInputPolicy.Or(_mockRightInputPolicy);

            var result = await or.ShouldProcessAsync(Item);

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public async Task Or_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(leftReturn));
            _mockRightInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(rightReturn));

            var or = new AsyncOr<int>(_mockLeftInputPolicy, _mockRightInputPolicy);

            var result = await or.ShouldProcessAsync(Item);

            result.Should().Be(expectedResult);
        }
    }
}