using CareerAPI.Domain.Entities;
using CareerAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Persistence.contexts
{
    public class CareerAPIDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public CareerAPIDbContext()
        {
        }

        public CareerAPIDbContext(DbContextOptions options):base(options) 
        { }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Advert> Advert { get; set; }
        public DbSet<ApplyAdvert> ApplyAdverts { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
