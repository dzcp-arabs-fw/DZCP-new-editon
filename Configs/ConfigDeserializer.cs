using System;
using System.IO;
using PlayerRoles;
using UnityEngine;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DZCP.Core.Configs
{
    /// <summary>
    /// نظام متقدم لتحميل وحفظ التهيئات مع دعم أنواع SCP:SL المخصصة
    /// </summary>
    public static class ConfigDeserializer
    {
        private static readonly IDeserializer _deserializer;
        private static readonly ISerializer _serializer;

        static ConfigDeserializer()
        {
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .WithTypeConverter(new ItemTypeConverter())
                .WithTypeConverter(new RoleTypeConverter())
                .WithTypeConverter(new Vector3Converter())
                .WithTypeConverter(new ColorConverter())
                .IgnoreUnmatchedProperties()
                .Build();

            _serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .WithTypeConverter(new ItemTypeConverter())
                .WithTypeConverter(new RoleTypeConverter())
                .WithTypeConverter(new Vector3Converter())
                .WithTypeConverter(new ColorConverter())
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.Preserve)
                .Build();
        }

        /// <summary>
        /// تحميل التهيئة من ملف YAML
        /// </summary>
        public static T Load<T>(string filePath) where T : IConfig, new()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    var defaultConfig = new T();
                    Save(filePath, defaultConfig);
                    return defaultConfig;
                }

                var yaml = File.ReadAllText(filePath);
                var config = _deserializer.Deserialize<T>(yaml);

                if (!config.Validate())
                {
                    Debug.LogWarning($"[DZCP] تهيئة غير صالحة في {filePath}، يتم استخدام القيم الافتراضية");
                    return new T();
                }

                return config;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[DZCP] خطأ في تحميل التهيئة من {filePath}:\n{ex}");
                return new T();
            }
        }

        /// <summary>
        /// حفظ التهيئة إلى ملف YAML
        /// </summary>
        public static void Save<T>(string filePath, T config) where T : IConfig
        {
            try
            {
                var yaml = _serializer.Serialize(config);
                File.WriteAllText(filePath, yaml);
            }
            catch (Exception ex)
            {
                Debug.LogError($"[DZCP] خطأ في حفظ التهيئة إلى {filePath}:\n{ex}");
            }
        }

        #region محولات أنواع SCP:SL المخصصة
        private class ItemTypeConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type == typeof(ItemType);

            public object ReadYaml(IParser parser, Type type)
            {
                var value = parser.Consume<Scalar>().Value;
                return Enum.TryParse(value, true, out ItemType result) ? result : ItemType.None;
            }

            public void WriteYaml(IEmitter emitter, object value, Type type)
            {
                emitter.Emit(new Scalar(value.ToString()));
            }
        }

        private class RoleTypeConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type == typeof(RoleTypeId);

            public object ReadYaml(IParser parser, Type type)
            {
                var value = parser.Consume<Scalar>().Value;
                return Enum.TryParse(value, true, out RoleTypeId result) ? result : RoleTypeId.None;
            }

            public void WriteYaml(IEmitter emitter, object value, Type type)
            {
                emitter.Emit(new Scalar(value.ToString()));
            }
        }

        private class Vector3Converter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type == typeof(Vector3);

            public object ReadYaml(IParser parser, Type type)
            {
                var value = parser.Consume<Scalar>().Value;
                var parts = value.Split(',');

                if (parts.Length == 3 &&
                    float.TryParse(parts[0], out float x) &&
                    float.TryParse(parts[1], out float y) &&
                    float.TryParse(parts[2], out float z))
                {
                    return new Vector3(x, y, z);
                }

                return Vector3.zero;
            }

            public void WriteYaml(IEmitter emitter, object value, Type type)
            {
                var vec = (Vector3)value;
                emitter.Emit(new Scalar($"{vec.x},{vec.y},{vec.z}"));
            }
        }

        private class ColorConverter : IYamlTypeConverter
        {
            public bool Accepts(Type type) => type == typeof(Color);

            public object ReadYaml(IParser parser, Type type)
            {
                var value = parser.Consume<Scalar>().Value;
                return ColorUtility.TryParseHtmlString(value, out Color color) ? color : Color.white;
            }

            public void WriteYaml(IEmitter emitter, object value, Type type)
            {
                var color = (Color)value;
                emitter.Emit(new Scalar($"#{ColorUtility.ToHtmlStringRGBA(color)}"));
            }
        }
        #endregion
    }

    /// <summary>
    /// واجهة أساسية لجميع التهيئات
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// التحقق من صحة قيم التهيئة
        /// </summary>
        bool Validate();
    }
}