using FinanceAPI.Domain.Interfaces;
using FinanceAPI.Infrastructure.Data;
using FinanceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(FinanceManagerDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
            => await _set
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email, ct);

        public async Task<User?> GetUserWithRoleAndPermissionsAsync(Guid userId, CancellationToken ct = default)
            => await _set
                .Include(u => u.Role)
                    .ThenInclude(r => r.RolePermissions)
                        .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(u => u.Id == userId, ct);
    }
}
