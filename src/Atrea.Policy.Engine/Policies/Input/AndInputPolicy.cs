namespace Atrea.Policy.Engine.Policies.Input
{
    public class AndInputPolicy<T> : IInputPolicy<T>
    {
        private readonly IInputPolicy<T> _leftInputPolicy;
        private readonly IInputPolicy<T> _rightInputPolicy;

        public AndInputPolicy(IInputPolicy<T> leftInputPolicy, IInputPolicy<T> rightInputPolicy)
        {
            _leftInputPolicy = leftInputPolicy;
            _rightInputPolicy = rightInputPolicy;
        }

        public InputPolicyResult ShouldProcess(T item)
        {
            var leftResult = _leftInputPolicy.ShouldProcess(item);

            if (leftResult == InputPolicyResult.Reject)
            {
                return InputPolicyResult.Reject;
            }

            var rightInputPolicyResult = _rightInputPolicy.ShouldProcess(item);

            if (rightInputPolicyResult == InputPolicyResult.Reject)
            {
                return InputPolicyResult.Reject;
            }

            if (leftResult == rightInputPolicyResult && leftResult == InputPolicyResult.Accept)
            {
                return InputPolicyResult.Accept;
            }

            return InputPolicyResult.Continue;
        }
    }
}