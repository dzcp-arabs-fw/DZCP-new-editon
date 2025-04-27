using System.Collections.Generic;
using System.IO;
using DZCP.API.Interfaces;
using Newtonsoft.Json;

namespace DZCP.API.Services
{
    public class TranslationServiceDzcp : ITranslation
    {
        private Dictionary<string, string> _translations = new();
        private readonly string _language;

        public TranslationServiceDzcp(string language = "en-US")
        {
            _language = language;
            LoadTranslations();
        }

        private void LoadTranslations()
        {
            string path = Path.Combine("resources", "translations", $"{_language}.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                _translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
        }

        public string this[string key] => throw new System.NotImplementedException();

        public string GetTranslation(string key, params object[] args)
        {
            if (_translations.TryGetValue(key, out string value))
            {
                return string.Format(value, args);
            }
            return key;
        }

        public void SetLanguage(string languageCode)
        {
            throw new System.NotImplementedException();
        }

        public void ReloadTranslations()
        {
            throw new System.NotImplementedException();
        }
    }
}
