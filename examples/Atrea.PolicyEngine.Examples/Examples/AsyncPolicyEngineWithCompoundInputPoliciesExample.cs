using System.Threading.Tasks;
using Atrea.PolicyEngine.Builders;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Policies.Input;

namespace Atrea.PolicyEngine.Examples.Examples;

public class AsyncPolicyEngineWithCompoundInputPoliciesExample : BaseAsyncExample
{
    public override async Task RunAsync()
    {
        // Configure the engine with the desired input policies, processors, and output policies.
        var engine = AsyncPolicyEngineBuilder<TranslatableItem>
            .Configure()
            .WithAsyncInputPolicies(
                // Ensure that the item has not yet been translated.
                NotYetTranslated,
                // The engine should process items if the translation being performed is for
                // items from US English to UK English OR from UK English to US English.
                FromUsEnglish.And(ToUkEnglish).Or(FromUkEnglish.And(ToUsEnglish))
            ).WithParallelProcessors(
                // Use the SingleWordTranslator and DictionaryTranslator to perform translations.
                // Note: translators will run in parallel.
                SingleWordTranslator,
                DictionaryTranslator
            ).WithParallelOutputPolicies(
                // After processing, publish the translation, mark the item as translated, and 
                // send a translation success email to the user who requested it.
                // Note: output policies will run in parallel.
                PublishTranslation,
                MarkItemTranslated,
                SendTranslationSuccessEmail
            ).Build();

        var translatableItem = new TranslatableItem();

        // Process the item.
        await engine.ProcessAsync(translatableItem);
    }
}