using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    [TestFixture]
    public class AsyncXorTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockLeftInputPolicy = Substitute.For<IAsyncInputPolicy<int>>();
            _mockRightInputPolicy = Substitute.For<IAsyncInputPolicy<int>>();
        }

        private const int Item = 1;

        private IAsyncInputPolicy<int> _mockLeftInputPolicy;
        private IAsyncInputPolicy<int> _mockRightInputPolicy;

        public static IEnumerable<TestCaseData> TestCases = CompoundBooleanInputPolicyTestCases.XorTestCases;

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public async Task AsyncXor_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(leftReturn));
            _mockRightInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(rightReturn));

            var or = new AsyncXor<int>(_mockLeftInputPolicy, _mockRightInputPolicy);

            var result = await or.ShouldProcessAsync(Item);

            result.Should().Be(expectedResult);
        }
    }
}