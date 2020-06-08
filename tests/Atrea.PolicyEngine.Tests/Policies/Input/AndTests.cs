using System.Collections.Generic;
using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    [TestFixture]
    public class AndTests
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

        public static IEnumerable<TestCaseData> TestCases = CompoundBooleanInputPolicyTestCases.AndTestCases;

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void And_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcess(Item).Returns(leftReturn);
            _mockRightInputPolicy.ShouldProcess(Item).Returns(rightReturn);

            var and = new And<int>(_mockLeftInputPolicy, _mockRightInputPolicy);

            var result = and.ShouldProcess(Item);

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Extension_Constructed_And_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcess(Item).Returns(leftReturn);
            _mockRightInputPolicy.ShouldProcess(Item).Returns(rightReturn);

            var and = _mockLeftInputPolicy.And(_mockRightInputPolicy);

            var result = and.ShouldProcess(Item);

            result.Should().Be(expectedResult);
        }
    }
}