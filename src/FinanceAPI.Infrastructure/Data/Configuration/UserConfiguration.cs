using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceAPI.Domain.Entities;

namespace FinanceAPI.Infrastructure.Data.Configuration
{
    // <summary>
    // Configuración de la entidad User para Entity Framework Core.
    // </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(u => u.Id);

            // Propiedades
            builder.Property(u => u.Id)
                .IsRequired();

            builder.Property(u => u.RoleId)
                .IsRequired();

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(u => u.IsActive)
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .IsRequired();

            builder.Property(u => u.LastLoginAt)
                .IsRequired(false); //nulleable, ya que un usuario puede no haber iniciado sesión aún.

            builder.Property(u => u.DeletedAt)
                .IsRequired(false); //nulleable, ya que un usuario puede no haber sido borrado (soft delete).

            // Índices
            builder.HasIndex(u => u.Username)
                .IsUnique()
                .HasDatabaseName("IX_Users_Username");

            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_Users_Email");

            // Relación con Role (muchos a uno)
            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict) // Evita la eliminación en cascada de roles.
                .HasConstraintName("FK_Users_Roles");

            // Relación con RefreshTokens (uno a muchos)
            builder.HasMany(u => u.RefreshTokens)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade) // Eliminar tokens de refresco al eliminar un usuario.
                .HasConstraintName("FK_RefreshTokens_Users");

            // Nombre de la tabla
            builder.ToTable("Users");
        }
    }
}
