using System;

public class DZCPServer
{
    public void StartServer()
    {
        Console.WriteLine("Server started...");
        // إضافة المزيد من الوظائف الخاصة بالسيرفر هنا
    }
}

public class DZCPMap
{
    public string MapName { get; set; }

    public void LoadMap(string mapName)
    {
        MapName = mapName;
        Console.WriteLine($"Map {mapName} loaded.");
    }
}

public static class DZCPUtils
{
    public static void Log(string message)
    {
        Console.WriteLine($"[DZCP Log]: {message}");
    }
}