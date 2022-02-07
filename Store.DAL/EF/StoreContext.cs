using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities.Base;
using Store.DAL.Entities.ItemProperties;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemBase>()
            .HasOne<Brand>(i => i.Brand);
        modelBuilder.Entity<ItemBase>()
            .HasOne<Model>(i => i.Model);
        modelBuilder.Entity<ItemBase>()
            .HasOne<Color>(i => i.Color);

        modelBuilder.Entity<CartItem>()
            .HasOne(c => c.User)
            .WithMany(u => u.CartItems);

        modelBuilder.Entity<Phone>()
            .HasOne<PhoneSpecifications>(p => p.Specifications);

        //modelBuilder.Entity<User>()
        //    .HasMany<CartItem>(u => u.CartItems)
        //    .WithOne(c => c.User);

        //modelBuilder.Entity<User>()
        //    .HasMany<CartItem>(u => u.CartItems);

        //modelBuilder.Entity<CartItem>()
        //    .HasOne(c => c.Item);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Brand> Brands { get; set; }

    public DbSet<Model> Models { get; set; }

    public DbSet<Color> Colors { get; set; }

    public DbSet<Image> Images { get; set; }

    public DbSet<Laptop> Laptops { get; set; }

    public DbSet<Phone> Phones { get; set; }

    public DbSet<PhoneSpecifications> PhoneSpecifications { get; set; }

    public DbSet<DeliveryOption> DeliveryOptions { get; set; }

    public DbSet<PaymentOption> PaymentOptions { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<CartItem> CartItems { get; set; }
}