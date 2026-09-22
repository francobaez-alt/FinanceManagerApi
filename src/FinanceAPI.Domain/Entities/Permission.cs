namespace FinanceAPI.Domain.Entities
{
    /// <summary>
    /// Entidad que representa un permiso en el sistema.
    /// </summary>
    public class Permission
    {
        // Propiedades
        public int Id { get; set; }
        public string Module { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        // Código único que representa el permiso utilizando las dos propiedades anteriores ({MODULO_ACTION} por ejemplo, "USER_CREATE", "USER_DELETE", etc.).
        public string Code { get; set; } = string.Empty;

        // Relaciones
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    }
}
