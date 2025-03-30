using System.Threading.Tasks;
using DZCP.Database;

namespace DZCP.Permissions.Providers
{
    public class DatabasePermissionProvider : IPermissionProvider
    {
        private IPermissionProvider _permissionProviderImplementation;

        public async Task InitializeAsync()
        {
            using var connection = await DatabaseManager.GetConnectionAsync();
            // Create permissions table if not exists
        }

        public async Task<bool> HasPermissionAsync(string userId, string permission)
        {
            using var connection = await DatabaseManager.GetConnectionAsync();
            // Query database for permission
            return false;
        }

        public async Task AddPermissionAsync(string userId, string permission)
        {
            using var connection = await DatabaseManager.GetConnectionAsync();
            // Add permission to database
        }

        public Task RemovePermissionAsync(string userId, string permission)
        {
            throw new System.NotImplementedException();
        }
    }
}
