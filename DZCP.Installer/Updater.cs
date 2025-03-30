using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DZCP.Logging;
using Newtonsoft.Json;

namespace DZCP.Updater
{
    public static class UpdaterService
    {
        private const string ReleasesUrl = "https://api.github.com/repos/YourName/DZCP/releases";
        
        public static async Task<bool> CheckForUpdates(Version currentVersion)
        {
            try
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "DZCP-Updater");
                
                var response = await httpClient.GetStringAsync(ReleasesUrl);
                var releases = JsonConvert.DeserializeObject<GitHubRelease[]>(response);
                
                if (releases.Length == 0)
                    return false;

                var latestRelease = releases[0];
                var latestVersion = new Version(latestRelease.TagName.TrimStart('v'));
                
                return latestVersion > currentVersion;
            }
            catch (Exception ex)
            {
                Logger.Error($"Update check failed: {ex}");
                return false;
            }
        }

        public static async Task<bool> DownloadUpdate(string downloadUrl, string destinationPath)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(downloadUrl);
                
                await using var fileStream = new FileStream(destinationPath, FileMode.Create);
                await response.Content.CopyToAsync(fileStream);
                
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Download failed: {ex}");
                return false;
            }
        }

        public static void ApplyUpdate(string updatePackagePath)
        {
            try
            {
                // Extract and replace files
                // Restart application if needed
            }
            catch (Exception ex)
            {
                Logger.Error($"Update failed: {ex}");
            }
        }
    }

    public class GitHubRelease
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }
        
        [JsonProperty("assets")]
        public GitHubAsset[] Assets { get; set; }
    }

    public class GitHubAsset
    {
        [JsonProperty("browser_download_url")]
        public string DownloadUrl { get; set; }
    }
}