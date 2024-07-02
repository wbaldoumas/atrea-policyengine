using System.Threading.Tasks;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Policies.Output;

namespace Atrea.PolicyEngine.Examples.Mocks.Policies.Output;

public class SendTranslationSuccessEmail : IOutputPolicy<TranslatableItem>, IAsyncOutputPolicy<TranslatableItem>
{
    public async Task ApplyAsync(TranslatableItem item)
    {
        // Implementation left to the imagination of the reader.
        await Task.Run(() => { });
    }

    public void Apply(TranslatableItem item)
    {
        // Implementation left to the imagination of the reader.
    }
}