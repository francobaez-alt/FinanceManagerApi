
using FinanceAPI.Domain.Common;
using System.Linq.Expressions;

namespace FinanceAPI.Domain.Interfaces
{
    public interface IRepository<T, TKey> where T : class
    {
        // Lectura
        Task<T?> GetByIdAsync(TKey id, CancellationToken ct = default);

        Task<IReadOnlyList<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken ct = default);

        Task<PagedResult<T>> GetPagedAsync(
        int page,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        CancellationToken ct = default);

        Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken ct = default);

        Task<bool> AnyAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken ct = default);

        Task<int> CountAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken ct = default);

        // Escritura
        Task AddAsync(T entity, CancellationToken ct = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);

        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
