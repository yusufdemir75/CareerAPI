using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerAPI.Application.Abstraction.Token;
using CareerAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace CareerAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<ICustomerTokenHandler, CustomerTokenHandler>();

        }
    }
}

