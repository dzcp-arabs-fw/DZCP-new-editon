using UnityEngine;

namespace DZCP.API.Roles
{
    /// <summary>
    /// الواجهة الأساسية لإنشاء أدوار مخصصة في SCP:SL
    /// </summary>
    public interface ICustomRole
    {
        /// <summary>
        /// المعرف الفريد للدور (يجب أن يكون مختلف لكل دور)
        /// </summary>
        int RoleID { get; }
        
        /// <summary>
        /// اسم الدور المعروض للاعبين
        /// </summary>
        string RoleName { get; }
        
        /// <summary>
        /// الفريق الذي ينتمي إليه الدور (SCP, MTF, Chaos, etc.)
        /// </summary>
        Team Team { get; }
        
        /// <summary>
        /// الصحة الابتدائية للدور
        /// </summary>
        float Health { get; }
        
        /// <summary>
        /// العناصر التي يحصل عليها الدور عند ظهوره
        /// </summary>
        ItemType[] StartItems { get; }
        
        /// <summary>
        /// لون الاسم في الشات وواجهة اللاعب
        /// </summary>
        Color RoleColor { get; }
        
        /// <summary>
        /// يتم استدعاؤها عند تعيين الدور للاعب
        /// </summary>
        void OnRoleAssigned(GameObject player);
        
        /// <summary>
        /// يتم استدعاؤها عند إزالة الدور من اللاعب
        /// </summary>
        void OnRoleRemoved(GameObject player);
    }
}