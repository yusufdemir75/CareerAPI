﻿using CareerAPI.Application.Repositories;
using CareerAPI.Domain.Entities.Common;
using CareerAPI.Persistence.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        readonly private CareerAPIDbContext _context;

        public WriteRepository(CareerAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
           EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
           EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync( data => data.Id == Guid.Parse(id));
            return Remove(model);
        }

        public async Task<bool> RemoveAdvertNoAsync(int advertNo)
        {
            if (typeof(T) == typeof(Domain.Entities.ApplyAdvert))
            {
                
                var model = await _context.ApplyAdverts.FirstOrDefaultAsync(data => data.AdvertNo == advertNo);

                if (model != null)
                {
                   
                    return Remove(model as T); 
                }
            }

            return false; 
        }

        public async Task<bool> RemoveAdvertNoAdvertAsync(int advertNo)
        {
            if (typeof(T) == typeof(Domain.Entities.Advert))
            {

                var model = await _context.ApplyAdverts.FirstOrDefaultAsync(data => data.AdvertNo == advertNo);

                if (model != null)
                {

                    return Remove(model as T);
                }
            }

            return false;
        }

        public bool Update(T model)
        {  
            Attach(model);

            EntityEntry entityEntry =
                Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public void Attach(T entity)
        {
            _context.Attach(entity);
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
    }
}
