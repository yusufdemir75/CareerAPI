using CareerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Persistence.contexts
{
    public class CareerAPIDbContext : DbContext
    {
        public CareerAPIDbContext(DbContextOptions options):base(options) 
        { }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Advert> Advert { get; set; }

    }
}
