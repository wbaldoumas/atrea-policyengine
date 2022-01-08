using System.Collections.Generic;
using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    [TestFixture]
    public class NotTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockInputPolicy = Substitute.For<IInputPolicy<int>>();
        }

        private const int Item = 1;

#nullable disable
        private IInputPolicy<int> _mockInputPolicy;
#nullable restore

        private static readonly IEnumerable<TestCaseData> TestCases = CompoundBooleanInputPolicyTestCases.NotTestCases;

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Not_Correctly_Evaluates_To_Expected_InputPolicyResult(
            InputPolicyResult mockReturn,
            InputPolicyResult expectedResult)
        {
            _mockInputPolicy.ShouldProcess(Item).Returns(mockReturn);

            var not = new Not<int>(_mockInputPolicy);

            var result = not.ShouldProcess(Item);

            result.Should().Be(expectedResult);
        }
    }
}