using CareerAPI.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using CareerAPI.Persistence.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Persistence
{
    public static class ServiceRegisteration
    {
        //Extension method
        public static void AddPersistenceServices(this IServiceCollection services) 
        {
            services.AddDbContext<CareerAPIDbContext>(options => options.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=CareerAPIDb;"));
    
        }
       
    }
}
