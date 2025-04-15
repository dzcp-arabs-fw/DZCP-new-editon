using System;
using System.Collections.Generic;

namespace DZCP
{
    public class PluginManager
    {
        public List<string> InstalledPlugins { get; private set; }

        public PluginManager(string testPlugins)
        {
            InstalledPlugins = new List<string>();
            LoadPlugins();
        }

        public PluginManager()
        {
        }


        // تحميل الإضافات المثبتة
        private void LoadPlugins()
        {
            // يمكنك تعديل هذا لتحميل الإضافات من ملفات أو من الإنترنت
            InstalledPlugins.Add("Plugin1");
            InstalledPlugins.Add("Plugin2");
            InstalledPlugins.Add("Plugin3");
        }

        // عرض قائمة الإضافات
        public void DisplayPlugins()
        {
            Console.WriteLine("الإضافات المثبتة:");
            foreach (var plugin in InstalledPlugins)
            {
                Console.WriteLine($"- {plugin}");
            }
        }

        // تثبيت إضافة جديدة
        public void InstallPlugin(string pluginName)
        {
            InstalledPlugins.Add(pluginName);
            Console.WriteLine($"تم تثبيت الإضافة: {pluginName}");
        }

        // تحديث إضافة
        public void UpdatePlugin(string pluginName)
        {
            Console.WriteLine($"تم تحديث الإضافة: {pluginName}");
            // هنا يمكنك وضع منطق التحديث (مثل تنزيل التحديثات من الإنترنت)
        }

        // إدارة الإضافات من خلال المستخدم
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("إدارة الإضافات:");
                Console.WriteLine("1. عرض الإضافات");
                Console.WriteLine("2. تثبيت إضافة");
                Console.WriteLine("3. تحديث إضافة");
                Console.WriteLine("4. خروج");
                Console.Write("اختيارك: ");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    DisplayPlugins();
                }
                else if (choice == "2")
                {
                    Console.Write("أدخل اسم الإضافة لتثبيتها: ");
                    string pluginName = Console.ReadLine();
                    InstallPlugin(pluginName);
                }
                else if (choice == "3")
                {
                    Console.Write("أدخل اسم الإضافة لتحديثها: ");
                    string pluginName = Console.ReadLine();
                    UpdatePlugin(pluginName);
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("اختيار غير صحيح. حاول مرة أخرى.");
                }

                Console.WriteLine("اضغط أي مفتاح للمتابعة...");
                Console.ReadKey();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PluginManager pluginManager = new PluginManager();
            pluginManager.Run();
        }
    }
}
