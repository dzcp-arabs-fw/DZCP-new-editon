using System;
using System.IO;
using UnityEngine;
using YamlDotNet.Serialization;

namespace DZCP.API.Roles
{
    /// <summary>
    /// نظام تحميل وحفظ تهيئات الأدوار
    /// </summary>
    public static class RoleConfig
    {
        private static readonly string ConfigPath = Path.Combine(Application.dataPath, "DZCP/Roles/Configs/");

        /// <summary>
        /// تحميل تهيئة الأدوار من ملف YAML
        /// </summary>
        public static T LoadRoleConfig<T>(string roleName) where T : new()
        {
            var filePath = Path.Combine(ConfigPath, $"{roleName}.yml");
            
            if (!File.Exists(filePath))
            {
                var defaultConfig = new T();
                SaveRoleConfig(roleName, defaultConfig);
                return defaultConfig;
            }

            try
            {
                var deserializer = new DeserializerBuilder().Build();
                return deserializer.Deserialize<T>(File.ReadAllText(filePath));
            }
            catch (Exception ex)
            {
                Debug.LogError($"[DZCP] خطأ في تحميل تهيئة الدور: {ex}");
                return new T();
            }
        }

        /// <summary>
        /// حفظ تهيئة الأدوار إلى ملف YAML
        /// </summary>
        public static void SaveRoleConfig<T>(string roleName, T config)
        {
            try
            {
                Directory.CreateDirectory(ConfigPath);
                var filePath = Path.Combine(ConfigPath, $"{roleName}.yml");
                
                var serializer = new SerializerBuilder().Build();
                File.WriteAllText(filePath, serializer.Serialize(config));
            }
            catch (Exception ex)
            {
                Debug.LogError($"[DZCP] خطأ في حفظ تهيئة الدور: {ex}");
            }
        }
    }
}