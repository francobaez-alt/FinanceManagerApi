using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceAPI.Domain.Entities;

namespace FinanceAPI.Infrastructure.Data.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        /// <summary>
        /// Configuración de la entidad Permission para Entity Framework Core.
        /// </summary>
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            // Primary Key
            builder.HasKey(p => p.Id);

            // Propiedades
            builder.Property(p => p.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Module)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Action)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(100);

            // Seeding de datos iniciales
            builder.HasData(
                // =========================
                // USER
                // =========================
                new Permission
                {
                    Id = 1,
                    Module = "USER",
                    Action = "CREATE",
                    Code = "USER_CREATE"
                },
                new Permission
                {
                    Id = 2,
                    Module = "USER",
                    Action = "READ",
                    Code = "USER_READ"
                },
                new Permission
                {
                    Id = 3,
                    Module = "USER",
                    Action = "UPDATE",
                    Code = "USER_UPDATE"
                },
                new Permission
                {
                    Id = 4,
                    Module = "USER",
                    Action = "DELETE",
                    Code = "USER_DELETE"
                },
                new Permission
                {
                    Id = 5,
                    Module = "USER",
                    Action = "LIST",
                    Code = "USER_LIST"
                },
                new Permission
                {
                    Id = 6,
                    Module = "USER",
                    Action = "RESET_PASSWORD",
                    Code = "USER_RESET_PASSWORD"
                },
                new Permission
                {
                    Id = 7,
                    Module = "USER",
                    Action = "CHANGE_PASSWORD",
                    Code = "USER_CHANGE_PASSWORD"
                },
                new Permission
                {
                    Id = 8,
                    Module = "USER",
                    Action = "ASSIGN_ROLE",
                    Code = "USER_ASSIGN_ROLE"
                },
                new Permission
                {
                    Id = 9,
                    Module = "USER",
                    Action = "ACTIVATE",
                    Code = "USER_ACTIVATE"
                },
                new Permission
                {
                    Id = 10,
                    Module = "USER",
                    Action = "DEACTIVATE",
                    Code = "USER_DEACTIVATE"
                },

                // =========================
                // ROLE
                // =========================
                new Permission
                {
                    Id = 11,
                    Module = "ROLE",
                    Action = "CREATE",
                    Code = "ROLE_CREATE"
                },
                new Permission
                {
                    Id = 12,
                    Module = "ROLE",
                    Action = "READ",
                    Code = "ROLE_READ"
                },
                new Permission
                {
                    Id = 13,
                    Module = "ROLE",
                    Action = "UPDATE",
                    Code = "ROLE_UPDATE"
                },
                new Permission
                {
                    Id = 14,
                    Module = "ROLE",
                    Action = "DELETE",
                    Code = "ROLE_DELETE"
                },
                new Permission
                {
                    Id = 15,
                    Module = "ROLE",
                    Action = "LIST",
                    Code = "ROLE_LIST"
                },

                // =========================
                // PERMISSION
                // =========================
                new Permission
                {
                    Id = 16,
                    Module = "PERMISSION",
                    Action = "READ",
                    Code = "PERMISSION_READ"
                },
                new Permission
                {
                    Id = 17,
                    Module = "PERMISSION",
                    Action = "LIST",
                    Code = "PERMISSION_LIST"
                },
                new Permission
                {
                    Id = 18,
                    Module = "PERMISSION",
                    Action = "ASSIGN_TO_ROLE",
                    Code = "PERMISSION_ASSIGN_TO_ROLE"
                },
                new Permission
                {
                    Id = 19,
                    Module = "PERMISSION",
                    Action = "REMOVE_FROM_ROLE",
                    Code = "PERMISSION_REMOVE_FROM_ROLE"
                },
                new Permission
                {
                    Id = 20,
                    Module = "PERMISSION",
                    Action = "VIEW_ROLE_PERMISSIONS",
                    Code = "PERMISSION_VIEW_ROLE_PERMISSIONS"
                },
                new Permission
                {
                    Id = 21,
                    Module = "PERMISSION",
                    Action = "VIEW_USER_PERMISSIONS",
                    Code = "PERMISSION_VIEW_USER_PERMISSIONS"
                },
                new Permission
                {
                    Id = 22,
                    Module = "PERMISSION",
                    Action = "CREATE",
                    Code = "PERMISSION_CREATE"
                },
                new Permission
                {
                    Id = 23,
                    Module = "PERMISSION",
                    Action = "UPDATE",
                    Code = "PERMISSION_UPDATE"
                },
                new Permission
                {
                    Id = 24,
                    Module = "PERMISSION",
                    Action = "DELETE",
                    Code = "PERMISSION_DELETE"
                }
            );

            // Nombre de tabla
            builder.ToTable("Permissions");
        }
    }
}

