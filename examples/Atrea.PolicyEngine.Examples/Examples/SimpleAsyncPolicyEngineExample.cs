using System.Threading.Tasks;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Examples.Mocks.Domain;

namespace Atrea.PolicyEngine.Examples.Examples;

public class SimpleAsyncPolicyEngineExample : BaseAsyncExample
{
    public override async Task RunAsync()
    {
        // Configure the engine with the desired input policies, processors, and output policies.
        var engine = AsyncPolicyEngineBuilder<TranslatableItem>
            .Configure()
            .WithAsyncInputPolicies(
                // Only process items that haven't yet be translated, and are translations from
                // Canadian French to US english.
                NotYetTranslated,
                FromCanadianFrench,
                ToUsEnglish
            ).WithParallelProcessors(
                // Use GoogleTranslator, MicrosoftTranslator, and CacheTranslator to perform translations.
                // Note: translators will run in parallel.
                GoogleTranslator,
                MicrosoftTranslator,
                CacheTranslator
            ).WithParallelOutputPolicies(
                // After processing, publish the translation and mark the item as translated.
                // Note: output policies will run in parallel.
                PublishTranslation,
                MarkItemTranslated
            ).Build();

        var translatableItem = new TranslatableItem();

        // Process the item.
        await engine.ProcessAsync(translatableItem);
    }
}