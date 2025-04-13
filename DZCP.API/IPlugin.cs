using System;

namespace DZCP.API
{
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        Version Version { get; }
        void Initialize();
        void Shutdown();
        
        void OnEnable();
        
        void OnDisable();
        void OnEnabled();
        void OnDisabled();
        public void EnablePlugin(string pluginName)
        {
            // تفعيل الإضافة
        }

        public void DisablePlugin(string pluginName)
        {
            // تعطيل الإضافة
        }

        public void RemovePlugin(string pluginName)
        {
            // إزالة الإضافة
        }

    }
}