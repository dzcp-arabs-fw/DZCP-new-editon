// DZCP/Core/Updater.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DZCP.Installer;
using DZCP.Loader;
using DZCP.Logging;
using DZCP.Loader;
using Newtonsoft.Json;
using PluginAPI.Helpers;
using UnityEngine.PlayerLoop;
using IPlugin = DZCP_new_editon.IPlugin;

public static class PluginUpdater
{
    public static async Task CheckUpdatesAsync()
    {
        using var http = new HttpClient();
        http.DefaultRequestHeaders.Add("User-Agent", "DZCP-Updater");

        var response = await http.GetStringAsync("https://api.dzcp.dev/plugins/updates");
        var updates = JsonConvert.DeserializeObject<List<DZCP.API.IPlugin>>(response);

        foreach (var update in updates)
        {
            if (update.Version > new Version(update.Name))
            {
                await DownloadUpdate(update.Author);
                Logger.Info($"تم تحديث {update.Name} إلى الإصدار {update.Version}");
            }
        }
    }

    private static async Task DownloadUpdate(string url)
    {
        string tempPath = Path.GetTempFileName();
        using var http = new HttpClient();
        var bytes = await http.GetByteArrayAsync(url);
         File.WriteAllText(tempPath, bytes.ToString());

        File.Copy(tempPath, Path.Combine(Paths.Plugins, Path.GetFileName(url)), true);
    }
}
