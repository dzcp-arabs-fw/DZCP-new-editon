// DZCP/Core/Updater.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DZCP.Logging;
using DZCP.Models;
using Newtonsoft.Json;
using PluginAPI.Helpers;

public static class PluginUpdater
{
    public static async Task CheckUpdatesAsync()
    {
        using var http = new HttpClient();
        http.DefaultRequestHeaders.Add("User-Agent", "DZCP-Updater");

        var response = await http.GetStringAsync("https://api.dzcp.dev/plugins/updates");
        var updates = JsonConvert.DeserializeObject<List<PluginUpdate>>(response);

        foreach (var update in updates)
        {
            if (update.Version > new Version(update.PluginId))
            {
                await DownloadUpdate(update.Url);
                Logger.Info($"تم تحديث {update.PluginName} إلى الإصدار {update.Version}");
            }
        }
    }

    private static async Task DownloadUpdate(string url)
    {
        string tempPath = Path.GetTempFileName();
        using var http = new HttpClient();
        var bytes = await http.GetByteArrayAsync(url);
        await File.WriteAllBytesAsync(tempPath, bytes);

        File.Copy(tempPath, Path.Combine(Paths.Plugins, Path.GetFileName(url)), true);
    }
}
