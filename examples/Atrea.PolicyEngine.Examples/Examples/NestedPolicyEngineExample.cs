using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Examples.Examples;

public class NestedPolicyEngineExample : BaseExample
{
    public override void Run()
    {
        var canadianFrenchTranslationEngine = BuildCanadianFrenchTranslationEngine();
        var englishTranslationEngine = BuildEnglishTranslationEngine();
        var numericTranslationEngine = BuildNumericTranslationEngine();

        var aggregateTranslationEngine = PolicyEngineBuilder<TranslatableItem>
            .Configure()
            // Only process items which have not yet been translated.
            .WithInputPolicies(NotYetTranslated)
            .WithProcessors(
                // Use the Canadian French, English, and Numeric translation engines to
                // perform translations.
                canadianFrenchTranslationEngine,
                englishTranslationEngine,
                numericTranslationEngine
            )
            // No output policies needed, since each individual engine handles its own
            // post-processing steps.
            .WithOutputPolicies()
            .Build();

        var translatableItem = new TranslatableItem();

        aggregateTranslationEngine.Process(translatableItem);
    }

    private static IPolicyEngine<TranslatableItem> BuildCanadianFrenchTranslationEngine() =>
        PolicyEngineBuilder<TranslatableItem>
            .Configure()
            .WithInputPolicies(
                // Only process items which have not yet been translated and are translations
                // that are either from Canadian French XOR to Canadian French.
                NotYetTranslated,
                FromCanadianFrench.Xor(ToCanadianFrench)
            ).WithProcessors(
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

    private static IPolicyEngine<TranslatableItem> BuildEnglishTranslationEngine() =>
        PolicyEngineBuilder<TranslatableItem>
            .Configure()
            .WithInputPolicies(
                // Only process items which have not yet been translated and are translations
                // that are from US English AND to UK English, OR are from UK English AND to US English.
                NotYetTranslated,
                FromUsEnglish.And(ToUkEnglish).Or(FromUkEnglish.And(ToUsEnglish))
            ).WithProcessors(
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

    private static IPolicyEngine<TranslatableItem> BuildNumericTranslationEngine() =>
        PolicyEngineBuilder<TranslatableItem>
            .Configure()
            .WithInputPolicies(
                // Only process items which have not yet been translated and are translations which
                // contain numeric text.
                NotYetTranslated,
                ContainsNumericText
            ).WithProcessors(
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