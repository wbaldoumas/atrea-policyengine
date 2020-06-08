using System.Threading.Tasks;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Examples.Mocks.Policies.Input;
using Atrea.PolicyEngine.Examples.Mocks.Policies.Output;
using Atrea.PolicyEngine.Examples.Mocks.Processors;

namespace Atrea.PolicyEngine.Examples.Examples
{
    public class SimpleAsyncPolicyEngineExample : IAsyncExample
    {
        public async Task RunAsync()
        {
            // Configure the engine with the desired input policies, processors, and output policies.
            var engine = AsyncPolicyEngineBuilder<TranslatableItem>
                .Configure()
                .WithAsyncInputPolicies(
                    // Only process items that haven't yet be translated, and are translations from
                    // Canadian French to US english.
                    new NotYetTranslated(),
                    new FromCanadianFrench(),
                    new ToUsEnglish()
                ).WithParallelProcessors(
                    // Use GoogleTranslator, MicrosoftTranslator, and CacheTranslator to perform translations.
                    // Note: translators will run in parallel.
                    new GoogleTranslator(),
                    new MicrosoftTranslator(),
                    new CacheTranslator()
                ).WithParallelOutputPolicies(
                    // After processing, publish the translation and mark the item as translated.
                    // Note: output policies will run in parallel.
                    new PublishTranslation(),
                    new MarkItemTranslated()
                ).Build();

            var translatableItem = new TranslatableItem();

            // Process the item.
            await engine.ProcessAsync(translatableItem);
        }
    }
}