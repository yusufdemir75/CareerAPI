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
using CareerAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Options;
using CareerAPI.Application.Repositories.ApplyAdvert;
using CareerAPI.Persistence.Repositories.ApplyAdvert;

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
            services.AddIdentity<AppUser,AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                
            }).AddEntityFrameworkStores<CareerAPIDbContext>();

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
            services.AddScoped<IApplyAdvertWriteRepository, ApplyAdvertWriteRepository>();
            services.AddScoped<IApplyAdvertReadRepository, ApplyAdvertReadRepository>();




        }

    }
}
