// DZCP/API/Interfaces/IAsyncCommand.cs
using System.Threading.Tasks;
using DZCP.API;
using DZCP.API.Models;

namespace DZCP.API.Interfaces
{
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// تنفيذ الأمر بشكل غير متزامن
        /// </summary>
        new Task<bool> ExecuteAsync(Player player, string[] args);
    }
}
