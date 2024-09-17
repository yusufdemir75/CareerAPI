using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        //add, delete , update process

        Task<bool> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> datas);

        bool Remove(T model);

        Task<bool> RemoveAdvertNoAdvertAsync(int advertNo);
        Task<bool> RemoveAdvertNoAsync(int advertNo);

        bool RemoveRange(List<T> datas);

        Task<bool> RemoveAsync(string id);

        bool Update(T model);

        void Attach(T entity);

        Task<int> SaveAsync();


    }
}
