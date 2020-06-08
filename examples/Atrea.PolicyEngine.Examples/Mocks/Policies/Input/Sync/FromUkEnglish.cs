using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Examples.Mocks.Policies.Input.Sync
{
    public class FromUkEnglish : IInputPolicy<TranslatableItem>
    {
        // Implementation left to the imagination of the reader.
        public InputPolicyResult ShouldProcess(TranslatableItem item) => InputPolicyResult.Continue;
    }
}