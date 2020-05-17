namespace Atrea.Policy.Engine.Policies.Input
{
    public class OrInputPolicy<T> : IInputPolicy<T>
    {
        private readonly IInputPolicy<T> _leftInputPolicy;
        private readonly IInputPolicy<T> _rightInputPolicy;

        public OrInputPolicy(IInputPolicy<T> leftInputPolicy, IInputPolicy<T> rightInputPolicy)
        {
            _leftInputPolicy = leftInputPolicy;
            _rightInputPolicy = rightInputPolicy;
        }

        public InputPolicyResult ShouldProcess(T item)
        {
            var leftResult = _leftInputPolicy.ShouldProcess(item);
            var rightResult = _rightInputPolicy.ShouldProcess(item);

            if (leftResult == InputPolicyResult.Accept || rightResult == InputPolicyResult.Accept)
            {
                return InputPolicyResult.Accept;
            }

            if (leftResult == InputPolicyResult.Continue || rightResult == InputPolicyResult.Continue)
            {
                return InputPolicyResult.Continue;
            }

            return InputPolicyResult.Reject;
        }
    }
}