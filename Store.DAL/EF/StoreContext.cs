using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.EntitiesForEnums;
using Store.DAL.Entities.Laptop;
using Store.DAL.Entities.Orders;
using Store.DAL.Entities.Phone;
using Store.DAL.Enums;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ItemBase>()
            .Property(i => i.BrandId)
            .HasConversion<int>();

        modelBuilder
            .Entity<Brand>()
            .Property(b => b.BrandId)
            .HasConversion<int>();

        modelBuilder
            .Entity<Brand>().HasData(
            Enum.GetValues(typeof(BrandId))
                .Cast<BrandId>()
                .Select(b => new Brand()
                {
                    BrandId = b,
                    Name = b.ToString()
                })
            );

        modelBuilder.Entity<Phone>()
            .HasOne<PhoneSpecifications>(p => p.Specifications);
        modelBuilder.Entity<Phone>()
            .Property(p => p.ColorHex).HasMaxLength(6);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Laptop> Laptops { get; set; }
    
    public DbSet<Phone> Phones { get; set; }
    
    public DbSet<PhoneSpecifications> PhoneSpecifications { get; set; }
    
    public DbSet<Order> Orders { get; set; }

    public DbSet<Brand> Brands { get; set; }
}