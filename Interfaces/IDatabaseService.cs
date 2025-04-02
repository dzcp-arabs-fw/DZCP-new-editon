// DZCP/API/Interfaces/IDatabaseService.cs
namespace DZCP.API.Interfaces
{
    public interface IDatabaseService
    {
        bool Connect(string connectionString);
        void Disconnect();
        bool Ping();
        void SaveData<T>(string key, T value);
        T GetData<T>(string key);
    }
}
