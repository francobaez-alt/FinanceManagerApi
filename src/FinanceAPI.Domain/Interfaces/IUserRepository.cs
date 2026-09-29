using FinanceAPI.Domain.Entities;
using FinanceAPI.Domain.Interfaces;

namespace FinanceAPI.Application.Interfaces
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
        Task<User?> GetUserWithRoleAndPermissionsAsync(Guid userId, CancellationToken ct = default);
    }
}
