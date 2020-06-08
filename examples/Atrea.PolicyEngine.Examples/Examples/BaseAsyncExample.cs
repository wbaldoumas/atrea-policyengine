using System.Threading.Tasks;
using Atrea.PolicyEngine.Examples.Mocks.Policies.Input.Async;
using Atrea.PolicyEngine.Examples.Mocks.Policies.Output;
using Atrea.PolicyEngine.Examples.Mocks.Processors;

namespace Atrea.PolicyEngine.Examples.Examples
{
    public abstract class BaseAsyncExample : IAsyncExample
    {
        public abstract Task RunAsync();

        #region input policies

        protected static readonly NotYetTranslated NotYetTranslated = new NotYetTranslated();
        protected static readonly FromUkEnglish FromUkEnglish = new FromUkEnglish();
        protected static readonly FromUsEnglish FromUsEnglish = new FromUsEnglish();
        protected static readonly FromCanadianFrench FromCanadianFrench = new FromCanadianFrench();
        protected static readonly ToUkEnglish ToUkEnglish = new ToUkEnglish();
        protected static readonly ToUsEnglish ToUsEnglish = new ToUsEnglish();
        protected static readonly ToCanadianFrench ToCanadianFrench = new ToCanadianFrench();
        protected static readonly ContainsNumericText ContainsNumericText = new ContainsNumericText();

        #endregion

        #region processors

        protected static readonly GoogleTranslator GoogleTranslator = new GoogleTranslator();
        protected static readonly MicrosoftTranslator MicrosoftTranslator = new MicrosoftTranslator();
        protected static readonly CacheTranslator CacheTranslator = new CacheTranslator();
        protected static readonly SingleWordTranslator SingleWordTranslator = new SingleWordTranslator();
        protected static readonly DictionaryTranslator DictionaryTranslator = new DictionaryTranslator();

        #endregion

        #region output policies

        protected static readonly PublishTranslation PublishTranslation = new PublishTranslation();
        protected static readonly MarkItemTranslated MarkItemTranslated = new MarkItemTranslated();

        protected static readonly SendTranslationSuccessEmail SendTranslationSuccessEmail =
            new SendTranslationSuccessEmail();

        #endregion
    }
}