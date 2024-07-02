using System.Collections.Generic;
using System.Threading.Tasks;
using Atrea.PolicyEngine.Examples.Examples;

namespace Atrea.PolicyEngine.Examples;

public static class ExampleRunner
{
    private static readonly IEnumerable<IExample> Examples = new List<IExample>
    {
        new SimplePolicyEngineExample(),
        new NestedPolicyEngineExample(),
        new PolicyEngineWithCompoundInputPoliciesExample()
    };

    private static readonly IEnumerable<IAsyncExample> AsyncExamples = new List<IAsyncExample>
    {
        new SimpleAsyncPolicyEngineExample(),
        new NestedAsyncPolicyEngineExample(),
        new AsyncPolicyEngineWithCompoundInputPoliciesExample()
    };

    public static async Task RunAsync()
    {
        foreach (var example in Examples)
        {
            example.Run();
        }

        foreach (var example in AsyncExamples)
        {
            await example.RunAsync();
        }
    }
}