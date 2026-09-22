using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinanceAPI.Domain.Entities
{
    // <summary>
    // Entidad que representa un token de refresco en el sistema.
    // </summary>
    public class RefreshToken
    {
        // Propiedades
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? RevokedAt { get; set; }
        public Guid? ReplacedByToken { get; set; }

        // Computed property
        [NotMapped]
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt; // Indica si el token ha expirado.
        [NotMapped]
        public bool IsActive => RevokedAt == null && !IsExpired; // Indica si el token está activo (no revocado y no expirado).

        // Relaciones
        public User User { get; set; } = null!;
    }
}
