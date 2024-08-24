using Microsoft.EntityFrameworkCore;
using CareerAPI.Persistence.contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CareerAPI.Application.Repositories;
using CareerAPI.Persistence.Repositories;

namespace CareerAPI.Persistence
{
    public static class ServiceRegisteration
    {
        //Extension method
        public static void AddPersistenceServices(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration) 
        {
            var connectionString = configuration.GetConnectionString("CareerAPIDb");
            services.AddDbContext<CareerAPIDbContext>(options =>
                options.UseNpgsql(connectionString),ServiceLifetime.Singleton);

            services.AddScoped<IAdvertReadRepository, AdvertReadRepository>();
            services.AddScoped<IAdvertWriteRepository, AdvertWriteRepository>();
            services.AddScoped<IAdminLogReadRepository, AdminLogReadRepository>();
            services.AddScoped<IAdminLogWriteRepository, AdminLogWriteRepository>();
            services.AddScoped<IApplicationsReadRepository, ApplicationsReadRepository>();
            services.AddScoped<IApplicationsWriteRepository, ApplicationsWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();


        }
       
    }
}
