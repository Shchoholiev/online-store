using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities.Laptop;
using Store.DAL.Entities.Orders;
using Store.DAL.Entities.Phone;

namespace Store.DAL.EF;

public class StoreContext : IdentityDbContext
{
    public StoreContext()
    {
    }
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = @"server=(LocalDb)\MSSQLLocalDB;database=Store;integrated security=True;
                    MultipleActiveResultSets=True;App=EntityFramework;";
        optionsBuilder.UseSqlServer(connectionString);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Phone>()
    //        .HasOne(p => p.Specifications)
    //        .WithMany();
    //    base.OnModelCreating(modelBuilder);

    //}

    public DbSet<Laptop> Laptops { get; set; }
        
    public DbSet<Phone> Phones { get; set; }
        
    public DbSet<PhoneSpecifications> PhoneSpecifications { get; set; }
        
    public DbSet<Order> Orders { get; set; }
}