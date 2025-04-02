using System.Threading.Tasks;

namespace DZCP.Permissions
{
    public interface IPermissionProvider
    {
        Task InitializeAsync();
        Task<bool> HasPermissionAsync(string userId, string permission);
        Task AddPermissionAsync(string userId, string permission);
        Task RemovePermissionAsync(string userId, string permission);
    }
}
