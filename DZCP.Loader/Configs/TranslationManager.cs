using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DZCP.NewEdition
{
    /// <summary>
    /// Manages plugin translations in the DZCP framework.
    /// </summary>
    public static class DZCPTranslationManager
    {
        public static SortedDictionary<string, IDZCPTranslation> Load(string rawTranslations)
        {
            try
            {
                ServerConsole.AddLog("[DZCP] Loading plugin translations...", ConsoleColor.Cyan);

                var rawDeserializedTranslations = DZCPCore.Instance.Deserializer.Deserialize<Dictionary<string, object>>(rawTranslations) ?? new Dictionary<string, object>();
                var deserializedTranslations = new SortedDictionary<string, IDZCPTranslation>(StringComparer.Ordinal);

                foreach (var plugin in DZCPAssemblyLoader.DZCPBootstrap.DZCPPluginLoader.Plugins)
                {
                    if (plugin is IDZCPTranslation translation)
                    {
                        deserializedTranslations.Add(plugin.Name, translation);
                    }
                }

                ServerConsole.AddLog("[DZCP] Plugin translations loaded successfully.", ConsoleColor.Green);
                return deserializedTranslations;
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"[DZCP] Error loading translations: {ex.Message}", ConsoleColor.Red);
                return null;
            }
        }

        public static bool Save(SortedDictionary<string, IDZCPTranslation> translations)
        {
            try
            {
                if (translations == null || translations.Count == 0)
                    return false;

                var serializedData = DZCPCore.Instance.Serializer.Serialize(translations);
                File.WriteAllText(DZCPCore.Instance.TranslationsPath, serializedData);

                ServerConsole.AddLog("[DZCP] Translations saved successfully.", ConsoleColor.Green);
                return true;
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"[DZCP] Error saving translations: {ex.Message}", ConsoleColor.Red);
                return false;
            }
        }
    }

    public interface IDZCPTranslation
    {
        void CopyProperties(IDZCPTranslation source);
    }
}