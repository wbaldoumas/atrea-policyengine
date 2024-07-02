using System.Threading.Tasks;
using Atrea.PolicyEngine.Examples.Mocks.Policies.Input.Async;
using Atrea.PolicyEngine.Examples.Mocks.Policies.Output;
using Atrea.PolicyEngine.Examples.Mocks.Processors;

namespace Atrea.PolicyEngine.Examples.Examples;

public abstract class BaseAsyncExample : IAsyncExample
{
    public abstract Task RunAsync();

    #region input policies

    protected static readonly NotYetTranslated NotYetTranslated = new();
    protected static readonly FromUkEnglish FromUkEnglish = new();
    protected static readonly FromUsEnglish FromUsEnglish = new();
    protected static readonly FromCanadianFrench FromCanadianFrench = new();
    protected static readonly ToUkEnglish ToUkEnglish = new();
    protected static readonly ToUsEnglish ToUsEnglish = new();
    protected static readonly ToCanadianFrench ToCanadianFrench = new();
    protected static readonly ContainsNumericText ContainsNumericText = new();

    #endregion

    #region processors

    protected static readonly GoogleTranslator GoogleTranslator = new();
    protected static readonly MicrosoftTranslator MicrosoftTranslator = new();
    protected static readonly CacheTranslator CacheTranslator = new();
    protected static readonly SingleWordTranslator SingleWordTranslator = new();
    protected static readonly DictionaryTranslator DictionaryTranslator = new();

    #endregion

    #region output policies

    protected static readonly PublishTranslation PublishTranslation = new();
    protected static readonly MarkItemTranslated MarkItemTranslated = new();

    protected static readonly SendTranslationSuccessEmail SendTranslationSuccessEmail = new();

    #endregion
}