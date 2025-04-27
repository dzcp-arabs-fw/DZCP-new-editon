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

        public abstract class PluginBase : IPlugin
        {
            public string Name { get; }
            
            Version DzcpVersion { get; }
            public string Author { get; }
            public Version Version { get; }
            public void Initialize()
            {
                throw new NotImplementedException();
            }

            public void Shutdown()
            {
                throw new NotImplementedException();
            }
            public virtual void OnEnable() { }
            public virtual void OnDisable() { }
            public void OnEnabled()
            {
                throw new NotImplementedException();
            }

            public void OnDisabled()
            {
                throw new NotImplementedException();
            }
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