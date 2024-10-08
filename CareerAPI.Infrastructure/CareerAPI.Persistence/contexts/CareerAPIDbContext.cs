﻿using CareerAPI.Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API ile konfigürasyon
            modelBuilder.Entity<AppUser>()
                .Property(u => u.imageUrl)
                .IsRequired(false);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.position)
                .IsRequired(false);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.address)
                .IsRequired(false);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.githubLink)
                .IsRequired(false);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.instaLink)
                .IsRequired(false);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.twitterLink)
                .IsRequired(false);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.age)
                .IsRequired(false);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.skills)
                .IsRequired(false);
            modelBuilder.Entity<AppUser>()
                .Property(u => u.cvUrl)
                .IsRequired(false);

            modelBuilder.Entity<ApplyAdvert>()
                .Property(a => a.AdvertNo)
                .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<ApplyAdvert>()
                .HasIndex(a => a.AdvertNo)
                .IsUnique();

            modelBuilder.Entity<Advert>()
                .Property(a => a.advertNo)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Advert>()
                .HasIndex(a => a.advertNo)
                .IsUnique();
        }

    }
}
