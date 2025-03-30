using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DZCP.API.Models;
using DZCP.Statistics;

namespace DZCP.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected void OnConfiguring(DbContextConfiguration options)
        {
        }
    }

    public class Permission
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string PermissionName { get; set; }
    }
}