using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Repository;
using Store.DAL.Entities.Phone;
using Store.BLL.Interfaces;
using Store.BLL.Services;
using Store.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Store.DAL.Entities.Orders;
using Store.DAL.Entities.Base;

namespace Store.BLL.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            var connectionString = @"server=(LocalDb)\MSSQLLocalDB;database=Store;integrated security=True;
                    MultipleActiveResultSets=True;App=EntityFramework;";

            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(connectionString)
                //ServiceLifetime.Singleton
            );

            services.AddScoped<IGenericRepository<CartItem>, GenericRepository<CartItem>>();
            services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
            services.AddScoped<IGenericRepository<DeliveryOption>, GenericRepository<DeliveryOption>>();
            services.AddScoped<IGenericRepository<PaymentOption>, GenericRepository<PaymentOption>>();

            services.AddScoped<IGenericRepository<Phone>, ItemsRepository<Phone>>();
            services.AddScoped<IGenericRepository<ItemBase>, ItemsRepository<ItemBase>>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<StoreContext>()
                    .AddDefaultTokenProviders();

            return services;
        }
    }
}
