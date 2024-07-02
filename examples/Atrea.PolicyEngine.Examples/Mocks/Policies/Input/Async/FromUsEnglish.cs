﻿using System.Threading.Tasks;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Examples.Mocks.Policies.Input.Async;

public class FromUsEnglish : IAsyncInputPolicy<TranslatableItem>
{
    public async Task<InputPolicyResult> ShouldProcessAsync(TranslatableItem item)
    {
        // Implementation left to the imagination of the reader.
        return await Task.Run(() => InputPolicyResult.Continue);
    }
}