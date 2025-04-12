using System;
using DZCP.Framework;

class ProgramFile
{
    static void Main(string[] args)
    {
        // تهيئة Doorstop Loader
        DoorstopLoader.Initialize();

        Console.WriteLine("Type 'reload' to reload the assembly or 'exit' to quit.");
        while (true)
        {
            var command = Console.ReadLine();
            if (command == "reload")
            {
                // إعادة تحميل الوحدة
                DoorstopLoader.Reload();
            }
            else if (command == "exit")
            {
                break;
            }
        }
    }
}