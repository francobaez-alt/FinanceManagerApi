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
    }
}
