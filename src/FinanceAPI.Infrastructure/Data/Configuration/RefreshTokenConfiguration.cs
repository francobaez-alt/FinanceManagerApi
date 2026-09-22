using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinanceAPI.Domain.Entities;

namespace FinanceAPI.Infrastructure.Data.Configuration
{ 
    // <summary>
    // Configuración de la entidad RefreshToken para Entity Framework Core.
    // </summary>
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // Primary Key
            builder.HasKey(rt => rt.Id);

            // Propiedades
            builder.Property(rt => rt.Id)
                .IsRequired();

            builder.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(rt => rt.ExpiresAt)
                .IsRequired();

            builder.Property(rt => rt.CreatedAt)
                .IsRequired();

            builder.Property(rt => rt.RevokedAt)
                .IsRequired(false); // nulleable, ya que un token puede no estar revocado.

            builder.Property(rt => rt.ReplacedByToken)
                .IsRequired(false); // nulleable, ya que un token puede no haber sido reemplazado.

            // Indices
            builder.HasIndex(rt => rt.Token)
                .IsUnique()
                .HasDatabaseName("IX_RefreshTokens_Token_Unique");

            builder.HasIndex(rt => rt.UserId)
                .HasDatabaseName("IX_RefreshTokens_UserId");

            builder.HasIndex(rt => rt.ReplacedByToken)
                .HasDatabaseName("IX_RefreshTokens_ReplacedByToken");

            builder.HasIndex(rt => rt.ExpiresAt)
                .HasDatabaseName("IX_RefreshTokens_ExpiresAt");

            // Relación con User (muchos a uno)
            builder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade) // Si un usuario se elimina, también se eliminan sus tokens asociados.
                .HasConstraintName("FK_RefreshTokens_Users");

            // Nombre de tabla
            builder.ToTable("RefreshTokens");
        }
    }
}
