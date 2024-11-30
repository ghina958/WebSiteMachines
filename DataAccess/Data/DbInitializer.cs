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


            AppUserRole role1 = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "Administrator",
                ConcurrencyStamp = "CA5E4BB1-5245-42DE-A631-6AF6B58E3CBD",
            };
            modelBuilder.Entity<AppUserRole>().HasData(role1);

            AppUserRole role2 = new()
            {
                Id = 2,
                Name = "User",
                NormalizedName = "User",
                ConcurrencyStamp = "50262EC3-A41E-47E5-BA7B-A04CB03062E5",
            };
            modelBuilder.Entity<AppUserRole>().HasData(role2);

            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasData(new IdentityUserRole<int> { RoleId = 1, UserId = 1 });

            //modelBuilder.Entity<IdentityUserRole<int>>()
            //   .HasData(new IdentityUserRole<int> { RoleId = 2, UserId = 1 });

            modelBuilder.Entity<IdentityUserRole<int>>()
            .HasData(new IdentityUserRole<int> { RoleId = 2, UserId = 2 });
        }
    }
}