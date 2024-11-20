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

            modelBuilder.Entity<AboutUs>()
        .Property(a => a.AdditionalImagePaths)
        .HasConversion(
            v => JsonConvert.SerializeObject(v), // Serialize to JSON string
            v => JsonConvert.DeserializeObject<List<string>>(v) // Deserialize JSON string back to List<string>
        )
        .Metadata.SetValueComparer(
            new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2), // Compare the collections
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Hash the collections for change tracking
                c => c.ToList() // Copy the collection to ensure EF Core has a stable copy
            )
        );


            new DbInitializer(modelBuilder);
            
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<MobileNumber> MobileNumber { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<SubService> SubServices { get; set; }


    }
}
