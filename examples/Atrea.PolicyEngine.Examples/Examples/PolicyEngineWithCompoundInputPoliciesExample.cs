using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Examples.Examples;

public class PolicyEngineWithCompoundInputPoliciesExample : BaseExample
{
    public override void Run()
    {
        // Configure the engine with the desired input policies, processors, and output policies.
        var engine = PolicyEngineBuilder<TranslatableItem>
            .Configure()
            .WithInputPolicies(
                // Ensure that the item has not yet been translated.
                NotYetTranslated,
                // The engine should process items if the translation being performed is for
                // items from US English to UK English OR from UK English to US English.
                FromUsEnglish.And(ToUkEnglish).Or(FromUkEnglish.And(ToUsEnglish))
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