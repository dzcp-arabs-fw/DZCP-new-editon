using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DZCP.Localization
{
    public class LanguageManager
    {
        private static Dictionary<string, string> languageDictionary;

        public static void LoadLanguage(string languageCode)
        {
            var filePath = $"DZCP/Localization/{languageCode}.json";
            var json = File.ReadAllText(filePath);
            languageDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static string GetString(string key)
        {
            return languageDictionary.ContainsKey(key) ? languageDictionary[key] : key;
        }
    }
}