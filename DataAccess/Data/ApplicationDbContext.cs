using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using WebSiteMachines.Models;

namespace WebSiteMachines.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser , AppUserRole , int>
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            new DbInitializer(modelBuilder);
            
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }   
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<OurTeam> OurTeam { get; set; }
        public DbSet<SliderImages> SliderImages { get; set; }
       
    }
}
