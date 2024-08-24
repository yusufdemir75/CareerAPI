using CareerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Repositories
{
    public interface IUserWriteRepository : IWriteRepository<User>
    {
    }
}
