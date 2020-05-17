namespace Atrea.Policy.Engine.Policies.Input
{
    public class XorInputPolicy<T> : IInputPolicy<T>
    {
        private readonly IInputPolicy<T> _leftInputPolicy;
        private readonly IInputPolicy<T> _rightInputPolicy;

        public XorInputPolicy(IInputPolicy<T> leftInputPolicy, IInputPolicy<T> rightInputPolicy)
        {
            _leftInputPolicy = leftInputPolicy;
            _rightInputPolicy = rightInputPolicy;
        }

        public InputPolicyResult ShouldProcess(T item)
        {
            var leftResult = _leftInputPolicy.ShouldProcess(item);
            var rightResult = _rightInputPolicy.ShouldProcess(item);

            if (ShouldProcess(InputPolicyResult.Accept, leftResult, rightResult))
            {
                return InputPolicyResult.Accept;
            }

            if (ShouldProcess(InputPolicyResult.Continue, leftResult, rightResult))
            {
                return InputPolicyResult.Continue;
            }

            return InputPolicyResult.Reject;
        }

        private static bool ShouldProcess(
            InputPolicyResult targetResult, InputPolicyResult leftResult,
            InputPolicyResult rightResult)
        {
            return leftResult == targetResult && rightResult != targetResult ||
                   leftResult != targetResult && rightResult == targetResult;
        }
    }
}