using FinanceAPI.Domain.Common;
using FinanceAPI.Domain.Interfaces;
using FinanceAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceAPI.Infrastructure.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly FinanceManagerDbContext _context;
        protected readonly DbSet<T> _set;

        public Repository(FinanceManagerDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        // Lectura
        public virtual async Task<T?> GetByIdAsync(TKey id, CancellationToken ct = default)
            => await _set.FindAsync(new object?[] { id }, ct);

        public virtual async Task<IReadOnlyList<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken ct = default)
        {
            IQueryable<T> query = _set.AsNoTracking();

            if (filter is not null)
                query = query.Where(filter);

            if (orderBy is not null)
                query = orderBy(query);

            return await query.ToListAsync(ct);
        }

        public virtual async Task<PagedResult<T>> GetPagedAsync(
            int page,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken ct = default)
        {
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, 100);

            IQueryable<T> query = _set.AsNoTracking();

            if (filter is not null)
                query = query.Where(filter);

            var totalCount = await query.CountAsync(ct);

            if (orderBy is not null)
                query = orderBy(query);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<T>(items, page, pageSize, totalCount); 
        }

        public virtual async Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken ct = default)
            => await _set.FirstOrDefaultAsync(predicate, ct);

        public virtual async Task<bool> AnyAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken ct = default)
            => await _set.AnyAsync(predicate, ct);

        public virtual async Task<int> CountAsync(
            Expression<Func<T, bool>>? predicate = null,
            CancellationToken ct = default)
            => predicate is null
                ? await _set.CountAsync(ct)
                : await _set.CountAsync(predicate, ct);

        // Escritura 
        public virtual async Task AddAsync(T entity, CancellationToken ct = default)
            => await _set.AddAsync(entity, ct);

        public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
            => await _set.AddRangeAsync(entities, ct);

        public virtual void Update(T entity) => _set.Update(entity);
        public virtual void Remove(T entity) => _set.Remove(entity);
        public virtual void RemoveRange(IEnumerable<T> entities) => _set.RemoveRange(entities);
    }
}
