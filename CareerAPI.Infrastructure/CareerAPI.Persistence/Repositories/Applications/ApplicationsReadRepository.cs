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
    public class ApplicationsReadRepository : ReadRepository<Applications>, IApplicationsReadRepository
    {
        public ApplicationsReadRepository(CareerAPIDbContext context) : base(context)
        {
        }
    }
}
