// DZCP/Services/Database/LiteDBService.cs
using LiteDB;
using DZCP.API.Interfaces;

namespace DZCP.Services.Database
{
    public class LiteDBService : IDatabaseService
    {
        private LiteDatabase _db;

        public bool Connect(string connectionString)
        {
            try
            {
                _db = new LiteDatabase(connectionString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            _db?.Dispose();
        }

        public bool Ping()
        {
            return _db != null && !_db.UtcDate;
        }

        public void SaveData<T>(string key, T value)
        {
            var collection = _db.GetCollection<T>("data");
            collection.Upsert(key, value);
        }

        public T GetData<T>(string key)
        {
            var collection = _db.GetCollection<T>("data");
            return collection.FindById(key);
        }
    }
}
