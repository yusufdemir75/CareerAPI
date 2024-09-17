using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T : BaseEntity
    {
        //Select process
         IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);

        Task<Domain.Entities.ApplyAdvert> GetApplyAdvertByAdvertNoAsync(int advertNo);

        Task<Domain.Entities.Advert> GetAdvertByAdvertNoAsync(int advertNo);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);

        Task<IEnumerable<T>> GetAllAsync(bool tracking = true);
    }
}
