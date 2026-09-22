using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceAPI.Domain.Entities;

namespace FinanceAPI.Infrastructure.Data.Configuration
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        /// <summary>
        /// Configuración de la entidad RolePermission para Entity Framework Core.
        /// </summary>
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            // Primary Key
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            // Relaciones
            builder.HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade) // Si un rol se elimina, también se eliminan sus permisos asociados.
                .HasConstraintName("FK_RolePermissions_Roles");

            builder.HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade) // Si un permiso se elimina, también se eliminan sus roles asociados.
                .HasConstraintName("FK_RolePermissions_Permissions");

            // Seeding de datos iniciales
            builder.HasData(
                // =========================
                // ADMIN - USER
                // =========================
                new RolePermission { RoleId = 1, PermissionId = 1 },  // USER_CREATE
                new RolePermission { RoleId = 1, PermissionId = 2 },  // USER_READ
                new RolePermission { RoleId = 1, PermissionId = 3 },  // USER_UPDATE
                new RolePermission { RoleId = 1, PermissionId = 4 },  // USER_DELETE
                new RolePermission { RoleId = 1, PermissionId = 5 },  // USER_LIST
                new RolePermission { RoleId = 1, PermissionId = 6 },  // USER_RESET_PASSWORD
                new RolePermission { RoleId = 1, PermissionId = 7 },  // USER_CHANGE_PASSWORD
                new RolePermission { RoleId = 1, PermissionId = 8 },  // USER_ASSIGN_ROLE
                new RolePermission { RoleId = 1, PermissionId = 9 },  // USER_ACTIVATE
                new RolePermission { RoleId = 1, PermissionId = 10 }, // USER_DEACTIVATE

                // =========================
                // ADMIN - ROLE
                // =========================
                new RolePermission { RoleId = 1, PermissionId = 11 }, // ROLE_CREATE
                new RolePermission { RoleId = 1, PermissionId = 12 }, // ROLE_READ
                new RolePermission { RoleId = 1, PermissionId = 13 }, // ROLE_UPDATE
                new RolePermission { RoleId = 1, PermissionId = 14 }, // ROLE_DELETE
                new RolePermission { RoleId = 1, PermissionId = 15 }, // ROLE_LIST

                // =========================
                // ADMIN - PERMISSION
                // =========================
                new RolePermission { RoleId = 1, PermissionId = 16 }, // PERMISSION_READ
                new RolePermission { RoleId = 1, PermissionId = 17 }, // PERMISSION_LIST
                new RolePermission { RoleId = 1, PermissionId = 18 }, // PERMISSION_ASSIGN_TO_ROLE
                new RolePermission { RoleId = 1, PermissionId = 19 }, // PERMISSION_REMOVE_FROM_ROLE
                new RolePermission { RoleId = 1, PermissionId = 20 }, // PERMISSION_VIEW_ROLE_PERMISSIONS
                new RolePermission { RoleId = 1, PermissionId = 21 }, // PERMISSION_VIEW_USER_PERMISSIONS
                new RolePermission { RoleId = 1, PermissionId = 22 }, // PERMISSION_CREATE
                new RolePermission { RoleId = 1, PermissionId = 23 }, // PERMISSION_UPDATE
                new RolePermission { RoleId = 1, PermissionId = 24 },  // PERMISSION_DELETE

                // =========================
                // USER - USER
                // =========================
                new RolePermission { RoleId = 2, PermissionId = 2 }, // USER_READ
                new RolePermission { RoleId = 2, PermissionId = 7 }  // USER_CHANGE_PASSWORD
                );

            // Nombre de tabla
            builder.ToTable("Role_Permissions");
        }
    }
}

