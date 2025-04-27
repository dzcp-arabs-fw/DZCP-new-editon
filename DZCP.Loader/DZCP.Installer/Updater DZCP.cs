using System;
using Octokit;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProductHeaderValue = Octokit.ProductHeaderValue;

namespace DZCP.Installer
{
    public static class Updater
    {
        public static async Task<bool> CheckAndUpdate(string currentVersion)
        {
            var client = new GitHubClient(new ProductHeaderValue("DZCP-Updater"));
            var releases = await client.Repository.Release.GetAll("DZCP-Team", "DZCP");

            if (releases.Count > 0 && releases[0].TagName != currentVersion)
            {
                var asset = releases[0].Assets[0];
                var download = await client.Connection.Get<object>(
                    new Uri(asset.BrowserDownloadUrl),
                    TimeSpan.FromMinutes(1));

                await File.WriteAllBytesAsync("DZCP_Update.zip", (byte[])download.Body);
                return true;
            }
            return false;
        }
    }
}