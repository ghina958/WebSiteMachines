using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using WebSiteMachines.Models;

namespace WebSiteMachines.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;

           
            ApplicationUser appUser = new()
            {
                Id = 1,
                FirstName = "sara",
                UserName = "sara123",
                NormalizedUserName = "SARA123",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "+905050367177",
                PhoneNumberConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
          
            var hasher = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = hasher.HashPassword(appUser, "sara123");
            modelBuilder.Entity<ApplicationUser>().HasData(appUser);

            ApplicationUser appUser2 = new()
            {
                Id = 2,
                FirstName = "ahmet",
                UserName = "ahmet2000",
                NormalizedUserName = "AHMET2000",
                Email = "ahmet@gmail.com",
                NormalizedEmail = "AHMET@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "+905050364355",
                PhoneNumberConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var hasher2 = new PasswordHasher<ApplicationUser>();
            appUser2.PasswordHash = hasher.HashPassword(appUser2, "ahmet2000");
            modelBuilder.Entity<ApplicationUser>().HasData(appUser2);
        }
    }
}