using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Examples.Mocks.Policies.Input;
using Atrea.PolicyEngine.Examples.Mocks.Policies.Output;
using Atrea.PolicyEngine.Examples.Mocks.Processors;

namespace Atrea.PolicyEngine.Examples.Examples
{
    public class SimplePolicyEngineExample : IExample
    {
        public void Run()
        {
            // Configure the engine with the desired input policies, processors, and output policies.
            var engine = PolicyEngineBuilder<TranslatableItem>
                .Configure()
                .WithInputPolicies(
                    // Only process items that haven't yet be translated, and are translations from
                    // US English to UK english.
                    new NotYetTranslated(),
                    new FromUsEnglish(),
                    new ToUkEnglish()
                ).WithProcessors(
                    // Use the SingleWordTranslator and DictionaryTranslator to perform translations.
                    new SingleWordTranslator(),
                    new DictionaryTranslator()
                ).WithOutputPolicies(
                    // After processing, publish the translation, mark the item as translated, and 
                    // send a translation success email to the user who requested it.
                    new PublishTranslation(),
                    new MarkItemTranslated(),
                    new SendTranslationSuccessEmail()
                ).Build();

            var translatableItem = new TranslatableItem();

            // Process the item.
            engine.Process(translatableItem);
        }
    }
}