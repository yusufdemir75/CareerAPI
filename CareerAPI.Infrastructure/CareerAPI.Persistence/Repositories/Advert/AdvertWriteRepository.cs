using CareerAPI.Application.Repositories;
using CareerAPI.Domain.Entities;
using CareerAPI.Persistence.contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Persistence.Repositories
{
    public class AdvertWriteRepository : WriteRepository<Advert>, IAdvertWriteRepository
    {
        public AdvertWriteRepository(CareerAPIDbContext context) : base(context)
        {
        }
    }
}
