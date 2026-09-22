using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceAPI.Domain.Entities
{
    // <summary>
    // Entidad que representa a un usuario en el sistema.
    // </summary>
    public class User
    {
        // Propiedades
        public Guid Id { get; set; } = Guid.NewGuid();
        public int RoleId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Computed property
        [NotMapped]
        public bool IsDeleted => DeletedAt.HasValue; // Indica si el usuario fue borrado (soft delete).
        [NotMapped]
        public bool IsAvailable => IsActive && !IsDeleted; // Indica si el usuario está activo y no fue borrado.
                                                           
        // Relaciones
        public Role Role { get; set; } = null!;
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
