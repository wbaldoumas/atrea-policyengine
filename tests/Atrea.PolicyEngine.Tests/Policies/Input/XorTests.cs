using System.Collections.Generic;
using Atrea.PolicyEngine.Policies.Input;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    [TestFixture]
    public class XorTests
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

        public static IEnumerable<TestCaseData> TestCases = CompoundBooleanInputPolicyTestCases.XorTestCases;

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Extension_Constructed_Xor_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcess(Item).Returns(leftReturn);
            _mockRightInputPolicy.ShouldProcess(Item).Returns(rightReturn);

            var xor = _mockLeftInputPolicy.Xor(_mockRightInputPolicy);

            var result = xor.ShouldProcess(Item);

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Xor_Returns_Expected_Result_Based_On_Component_Return_Values(
            InputPolicyResult leftReturn,
            InputPolicyResult rightReturn,
            InputPolicyResult expectedResult)
        {
            _mockLeftInputPolicy.ShouldProcess(Item).Returns(leftReturn);
            _mockRightInputPolicy.ShouldProcess(Item).Returns(rightReturn);

            var xor = new Xor<int>(_mockLeftInputPolicy, _mockRightInputPolicy);

            var result = xor.ShouldProcess(Item);

            result.Should().Be(expectedResult);
        }
    }
}