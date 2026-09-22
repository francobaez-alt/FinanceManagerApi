using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAPI.Domain.Entities
{
    // <summary>
    // Entidad que representa la relación entre roles y permisos.
    // </summary>
    public class RolePermission
    {
        // Propiedades
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        // Relaciones
        public Role Role { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}
