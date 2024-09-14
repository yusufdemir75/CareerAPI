using CareerAPI.Application.Repositories.ApplyAdvert;
using CareerAPI.Domain.Entities;
using CareerAPI.Persistence.contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Persistence.Repositories.ApplyAdvert
{
    public class ApplyAdvertReadRepository : ReadRepository<Domain.Entities.ApplyAdvert>, IApplyAdvertReadRepository
    {
        public ApplyAdvertReadRepository(CareerAPIDbContext context) : base(context)
        {
        }
    }
}
