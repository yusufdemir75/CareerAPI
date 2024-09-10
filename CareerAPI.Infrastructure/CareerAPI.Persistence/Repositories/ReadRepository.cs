using CareerAPI.Application.Repositories;
using CareerAPI.Domain.Entities.Common;
using CareerAPI.Persistence.contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Persistence.Repositories
{

    
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

        private readonly CareerAPIDbContext _context;
        public ReadRepository(CareerAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        // => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }


        public async Task<T> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.ToListAsync();  // Liste olarak dön
        }

    }
}
