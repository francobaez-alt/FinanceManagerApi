namespace FinanceAPI.Domain.Entities
{
    /// <summary>
    /// Entidad que representa un rol en el sistema.
    /// </summary>
    public class Role
    {
        // Propiedades
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Relaciones
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
