using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Examples.Mocks.Domain;

namespace Atrea.PolicyEngine.Examples.Examples
{
    public class SimplePolicyEngineExample : BaseExample
    {
        public override void Run()
        {
            // Configure the engine with the desired input policies, processors, and output policies.
            var engine = PolicyEngineBuilder<TranslatableItem>
                .Configure()
                .WithInputPolicies(
                    // Only process items that haven't yet be translated, and are translations from
                    // US English to UK english.
                    NotYetTranslated,
                    FromUsEnglish,
                    ToUkEnglish
                ).WithProcessors(
                    // Use the SingleWordTranslator and DictionaryTranslator to perform translations.
                    SingleWordTranslator,
                    DictionaryTranslator
                ).WithOutputPolicies(
                    // After processing, publish the translation, mark the item as translated, and 
                    // send a translation success email to the user who requested it.
                    PublishTranslation,
                    MarkItemTranslated,
                    SendTranslationSuccessEmail
                ).Build();

            var translatableItem = new TranslatableItem();

            // Process the item.
            engine.Process(translatableItem);
        }
    }
}