using System.Collections.Generic;
using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    [TestFixture]
    public class OrTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockLeftInputPolicy = Substitute.For<IInputPolicy<int>>();
            _mockRightInputPolicy = Substitute.For<IInputPolicy<int>>();
        }

        private const int Item = 1;

        private IInputPolicy<int> _mockLeftInputPolicy;
        private IInputPolicy<int> _mockRightInputPolicy;

        public static IEnumerable<TestCaseData> TestCases = CompoundBooleanInputPolicyTestCases.OrTestCases;

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Or_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcess(Item).Returns(leftReturn);
            _mockRightInputPolicy.ShouldProcess(Item).Returns(rightReturn);

            var or = new Or<int>(_mockLeftInputPolicy, _mockRightInputPolicy);

            var result = or.ShouldProcess(Item);

            result.Should().Be(expectedResult);
        }
    }
}