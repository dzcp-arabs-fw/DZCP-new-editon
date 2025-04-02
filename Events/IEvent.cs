// DZCP/API/Events/IEvent.cs
namespace DZCP.API.Events
{
    /// <summary>
    /// الواجهة الأساسية لجميع أحداث DZCP
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// تحديد ما إذا كان الحدث ملغى
        /// </summary>
        bool IsCancelled { get; set; }
    }
}
