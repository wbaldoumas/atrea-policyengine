using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    [TestFixture]
    public class AsyncAndTests
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

        private static readonly IEnumerable<TestCaseData> TestCases = CompoundBooleanInputPolicyTestCases.AndTestCases;

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public async Task AsyncAnd_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(leftReturn));
            _mockRightInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(rightReturn));

            var and = new AsyncAnd<int>(_mockLeftInputPolicy, _mockRightInputPolicy);

            var result = await and.ShouldProcessAsync(Item);

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public async Task Extension_Constructed_AsyncAnd_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(leftReturn));
            _mockRightInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(rightReturn));

            var and = _mockLeftInputPolicy.And(_mockRightInputPolicy);

            var result = await and.ShouldProcessAsync(Item);

            result.Should().Be(expectedResult);
        }
    }
}