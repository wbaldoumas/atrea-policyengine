using System.Threading.Tasks;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Examples.Examples
{
    public class NestedAsyncPolicyEngineExample : BaseAsyncExample
    {
        public override async Task RunAsync()
        {
            var canadianFrenchTranslationEngine = BuildCanadianFrenchTranslationEngine();
            var englishTranslationEngine = BuildEnglishTranslationEngine();
            var numericTranslationEngine = BuildNumericTranslationEngine();

            var aggregateTranslationEngine = AsyncPolicyEngineBuilder<TranslatableItem>
                .Configure()
                // Only process items which have not yet been translated.
                .WithAsyncInputPolicies(NotYetTranslated)
                .WithParallelProcessors(
                    // Use the Canadian French, English, and Numeric translation engines to
                    // perform translations.
                    // Note: translation engines will run in parallel.
                    canadianFrenchTranslationEngine,
                    englishTranslationEngine,
                    numericTranslationEngine
                )
                // No output policies needed, since each individual engine handles its own
                // post-processing steps.
                .WithOutputPolicies()
                .Build();

            var translatableItem = new TranslatableItem();

            await aggregateTranslationEngine.ProcessAsync(translatableItem);
        }

        private static IAsyncPolicyEngine<TranslatableItem> BuildCanadianFrenchTranslationEngine() =>
            AsyncPolicyEngineBuilder<TranslatableItem>
                .Configure()
                .WithAsyncInputPolicies(
                    // Only process items which have not yet been translated and are translations
                    // that are either from Canadian French XOR to Canadian French.
                    NotYetTranslated,
                    FromCanadianFrench.Xor(ToCanadianFrench)
                ).WithAsyncProcessors(
                    // Use the GoogleTranslator, MicrosoftTranslator, and CacheTranslator to perform
                    // translations.
                    GoogleTranslator,
                    MicrosoftTranslator,
                    CacheTranslator
                ).WithOutputPolicies(
                    // After processing, publish the translation, mark the item as translated, and 
                    // send a translation success email to the user who requested it.
                    PublishTranslation,
                    MarkItemTranslated,
                    SendTranslationSuccessEmail
                )
                .Build();

        private static IAsyncPolicyEngine<TranslatableItem> BuildEnglishTranslationEngine() =>
            AsyncPolicyEngineBuilder<TranslatableItem>
                .Configure()
                .WithAsyncInputPolicies(
                    // Only process items which have not yet been translated and are translations
                    // that are from US English AND to UK English, OR are from UK English AND to US English.
                    NotYetTranslated,
                    FromUsEnglish.And(ToUkEnglish).Or(FromUkEnglish.And(ToUsEnglish))
                ).WithAsyncProcessors(
                    // Use the SingleWordTranslator and DictionaryTranslator to perform translations.
                    SingleWordTranslator,
                    DictionaryTranslator
                ).WithOutputPolicies(
                    // After processing, publish the translation, mark the item as translated, and 
                    // send a translation success email to the user who requested it.
                    PublishTranslation,
                    MarkItemTranslated
                )
                .Build();

        private static IAsyncPolicyEngine<TranslatableItem> BuildNumericTranslationEngine() =>
            AsyncPolicyEngineBuilder<TranslatableItem>
                .Configure()
                .WithAsyncInputPolicies(
                    // Only process items which have not yet been translated and are translations which
                    // contain numeric text.
                    NotYetTranslated,
                    ContainsNumericText
                ).WithAsyncProcessors(
                    // Use the SingleWordTranslator to perform translations.
                    SingleWordTranslator
                ).WithOutputPolicies(
                    // After processing, publish the translation, mark the item as translated, and 
                    // send a translation success email to the user who requested it.
                    PublishTranslation,
                    MarkItemTranslated
                )
                .Build();
    }
}