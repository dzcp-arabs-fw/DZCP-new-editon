// DZCP/API/Interfaces/ICommand.cs

using System.Threading.Tasks;
using DZCP.API;
using DZCP.API.Models;

namespace DZCP.API.Interfaces
{
    /// <summary>
    /// الواجهة الأساسية لجميع أوامر DZCP
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// اسم الأمر الرئيسي
        /// </summary>
        string Command { get; }

        /// <summary>
        /// الأسماء البديلة للأمر
        /// </summary>
        string[] Aliases { get; }

        /// <summary>
        /// وصف الأمر
        /// </summary>
        string Description { get; }

        /// <summary>
        /// طريقة التنفيذ
        /// </summary>
        bool Execute(Player player, string[] args);

        /// <summary>
        /// طريقة التنفيذ الغير متزامنة
        /// </summary>
        Task<bool> ExecuteAsync(Player player, string[] args);
    }
}
