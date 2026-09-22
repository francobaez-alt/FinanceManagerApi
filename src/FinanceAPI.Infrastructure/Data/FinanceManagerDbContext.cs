using Microsoft.EntityFrameworkCore;
using FinanceAPI.Domain.Entities;
using FinanceAPI.Infrastructure.Data.Configuration;

namespace FinanceAPI.Infrastructure.Data
{
    /// <summary>
    /// Contexto de base de datos para la aplicación FinanceAPI.
    /// </summary>
    internal class FinanceManagerDbContext : DbContext
    {
        public FinanceManagerDbContext(DbContextOptions<FinanceManagerDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(FinanceManagerDbContext).Assembly);

        }
    }
}
