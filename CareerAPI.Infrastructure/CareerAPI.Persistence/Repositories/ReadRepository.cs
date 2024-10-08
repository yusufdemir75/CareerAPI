﻿using CareerAPI.Application.Repositories;
using CareerAPI.Domain.Entities;
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

        public async Task<Domain.Entities.ApplyAdvert> GetApplyAdvertByAdvertNoAsync(int advertNo)
        {
            return await _context.ApplyAdverts.FirstOrDefaultAsync(a => a.AdvertNo == advertNo);
        }

        public async Task<Domain.Entities.Advert> GetAdvertByAdvertNoAsync(int advertNo)
        {
            return await _context.Advert.FirstOrDefaultAsync(a => a.advertNo == advertNo);
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

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
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
            return await query.ToListAsync();  
        }

        public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }
    }
}
