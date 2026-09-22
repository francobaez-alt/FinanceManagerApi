using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceAPI.Domain.Entities;

namespace FinanceAPI.Infrastructure.Data.Configuration
{
    // <summary>
    // Configuración de la entidad Role para Entity Framework Core.
    // </summary>
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Primary Key
            builder.HasKey(r => r.Id);

            // Propiedades
            builder.Property(r => r.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Índices
            builder.HasIndex(r => r.Name)
                .IsUnique()
                .HasDatabaseName("IX_Roles_Name_Unique");

            // Relaciones con RolePermissions (uno a muchos)
            builder.HasMany(r => r.RolePermissions)
                .WithOne(rp => rp.Role)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade) // Si un rol se elimina, también se eliminan sus permisos asociados.
                .HasConstraintName("FK_RolePermissions_Roles");

            // Seeding de datos iniciales
            builder.HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

            // Nombre de tabla
            builder.ToTable("Roles");
        }
    }
}
