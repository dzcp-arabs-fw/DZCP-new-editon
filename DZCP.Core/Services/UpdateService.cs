using Octokit;
using System;
using System.Threading.Tasks;

namespace DZCP.Services
{
    public class UpdateService
    {
        private static GitHubClient client = new GitHubClient(new ProductHeaderValue("DZCP"));

        public async Task CheckForUpdates()
        {
            var releases = await client.Repository.Release.GetAll("DZCP-new-editon", "DZCP");
            var latestRelease = releases[0];
            if (latestRelease.PublishedAt > DateTime.Now )
            {
                Console.WriteLine("New version available!");
                // من هنا يمكنك تحميل التحديث
            }
        }
    }
}