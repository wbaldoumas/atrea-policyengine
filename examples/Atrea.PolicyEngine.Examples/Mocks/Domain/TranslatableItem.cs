namespace Atrea.PolicyEngine.Examples.Mocks.Domain
{
    public class TranslatableItem
    {
        public string FromLanguage { get; set; }
        public string ToLanguage { get; set; }
        public string SourceText { get; set; }
        public string TranslatedText { get; set; }
        public bool IsTranslated => !string.IsNullOrEmpty(TranslatedText);
    }
}