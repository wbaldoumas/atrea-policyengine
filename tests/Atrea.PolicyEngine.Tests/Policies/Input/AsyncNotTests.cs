using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    public class AsyncNotTests
    {
        private const int Item = 1;

        private static readonly IEnumerable<TestCaseData> TestCases = CompoundBooleanInputPolicyTestCases.NotTestCases;

#nullable disable
        private IAsyncInputPolicy<int> _mockInputPolicy;
#nullable restore

        [SetUp]
        public void SetUp()
        {
            _mockInputPolicy = Substitute.For<IAsyncInputPolicy<int>>();
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public async Task Not_Correctly_Evaluates_To_Expected_InputPolicyResult(
            InputPolicyResult mockReturn,
            InputPolicyResult expectedResult)
        {
            _mockInputPolicy.ShouldProcessAsync(Item).Returns(Task.FromResult(mockReturn));

            var not = new AsyncNot<int>(_mockInputPolicy);

            var result = await not.ShouldProcessAsync(Item);

            result.Should().Be(expectedResult);
        }
    }
}