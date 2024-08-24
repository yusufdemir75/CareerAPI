using CareerAPI.Application.Repositories;
using CareerAPI.Domain.Entities;
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
    public class AdvertReadRepository : ReadRepository<Advert>, IAdvertReadRepository
    {
        public AdvertReadRepository(CareerAPIDbContext context) : base(context)
        {
        }

    }
}
