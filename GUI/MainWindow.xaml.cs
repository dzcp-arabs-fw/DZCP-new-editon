using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Eagle._Tests;

namespace DZCP.GUI
{
    public partial class MainWindow : Default.Win32Window
    {
        private Dictionary<string, string> languageDictionary;

        public MainWindow()
        {
            LoadLanguage("en");
        }

        private void LoadLanguage(string languageCode)
        {
            var filePath = $"DZCP/Localization/{languageCode}.json";
            var json = File.ReadAllText(filePath);
            languageDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        private void ChangeLanguage(string newLanguage)
        {
            LoadLanguage(newLanguage);
            // تحديث العناصر بناءً على اللغة الجديدة
        }
    }
}