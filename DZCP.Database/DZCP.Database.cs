using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DZCP.Database
{
    public interface IDatabaseProvider
    {
        Task InitializeAsync();
        Task<DbConnection> GetConnectionAsync();
    }

    public class DatabaseManager
    {
        private static IDatabaseProvider _provider;

        public static void Initialize(DatabaseType type, string connectionString)
        {
            _provider = type switch
            {
                DatabaseType.MySQL => new MySqlProvider(connectionString),
                DatabaseType.SQLite => new SQLiteProvider(connectionString),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static async Task<DbConnection> GetConnectionAsync()
        {
            if (_provider == null)
                throw new InvalidOperationException("Database provider not initialized");

            return await _provider.GetConnectionAsync();
        }
    }

    public class MySqlProvider : IDatabaseProvider
    {
        private readonly string _connectionString;

        public MySqlProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task InitializeAsync()
        {
            using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            // Create tables if not exists
        }

        public async Task<DbConnection> GetConnectionAsync()
        {
            var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }

    public class SQLiteProvider : IDatabaseProvider
    {
        private readonly string _connectionString;

        public SQLiteProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task InitializeAsync()
        {
            using var connection = new SQLiteConnection(_connectionString);
            // Create tables if not exists
            await Task.CompletedTask;
        }

        public async Task<DbConnection> GetConnectionAsync()
        {
            var connection = new SQLiteConnection(_connectionString);
            await Task.CompletedTask;
            return connection;
        }
    }

    public enum DatabaseType
    {
        MySQL,
        SQLite
    }
}
