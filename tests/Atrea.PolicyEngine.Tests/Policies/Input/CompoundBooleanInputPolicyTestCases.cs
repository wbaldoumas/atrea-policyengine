using System.Collections.Generic;
using Atrea.PolicyEngine.Policies.Input;
using NUnit.Framework;

namespace Atrea.PolicyEngine.Tests.Policies.Input
{
    public static class CompoundBooleanInputPolicyTestCases
    {
        public static IEnumerable<TestCaseData> AndTestCases
        {
            get
            {
                yield return new TestCaseData(
                    InputPolicyResult.Reject,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Reject
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Reject,
                    InputPolicyResult.Reject
                );

                yield return new TestCaseData(
                    InputPolicyResult.Accept,
                    InputPolicyResult.Accept,
                    InputPolicyResult.Accept
                );

                yield return new TestCaseData(
                    InputPolicyResult.Accept,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Accept,
                    InputPolicyResult.Continue
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue
                );
            }
        }

        public static IEnumerable<TestCaseData> OrTestCases
        {
            get
            {
                yield return new TestCaseData(
                    InputPolicyResult.Reject,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Reject,
                    InputPolicyResult.Continue
                );

                yield return new TestCaseData(
                    InputPolicyResult.Accept,
                    InputPolicyResult.Accept,
                    InputPolicyResult.Accept
                );

                yield return new TestCaseData(
                    InputPolicyResult.Accept,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Accept
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Accept,
                    InputPolicyResult.Accept
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue
                );

                yield return new TestCaseData(
                    InputPolicyResult.Reject,
                    InputPolicyResult.Reject,
                    InputPolicyResult.Reject
                );
            }
        }

        public static IEnumerable<TestCaseData> XorTestCases
        {
            get
            {
                yield return new TestCaseData(
                    InputPolicyResult.Reject,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Reject,
                    InputPolicyResult.Continue
                );

                yield return new TestCaseData(
                    InputPolicyResult.Accept,
                    InputPolicyResult.Accept,
                    InputPolicyResult.Reject
                );

                yield return new TestCaseData(
                    InputPolicyResult.Accept,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Accept
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Accept,
                    InputPolicyResult.Accept
                );

                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Continue,
                    InputPolicyResult.Reject
                );
            }
        }

        public static IEnumerable<TestCaseData> NotTestCases
        {
            get
            {
                yield return new TestCaseData(
                    InputPolicyResult.Continue,
                    InputPolicyResult.Reject
                );

                yield return new TestCaseData(
                    InputPolicyResult.Accept,
                    InputPolicyResult.Reject
                );

                yield return new TestCaseData(
                    InputPolicyResult.Reject,
                    InputPolicyResult.Continue
                );
            }
        }
    }
}