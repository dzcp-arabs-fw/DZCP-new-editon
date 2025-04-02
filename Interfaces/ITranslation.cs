namespace DZCP.API.Interfaces
{
    public interface ITranslation
    {
        string this[string key] { get; }
        string GetTranslation(string key, params object[] args);
        void SetLanguage(string languageCode);
        void ReloadTranslations();
    }
}
