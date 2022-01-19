using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.BLL.Services;
using Store.DAL.DataInitializer;
using Store.DAL.EF;
using Store.DAL.Entities.Identity;
using Store.DAL.Entities.Phone;
using Store.DAL.Repository;

using (var context = new StoreContext())
{
    DbInitializer.Delete(context);
    DbInitializer.Initialize(context);
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = @"server=(LocalDb)\MSSQLLocalDB;database=Store;integrated security=True;
                    MultipleActiveResultSets=True;App=EntityFramework;";

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IGenericRepository<Phone>, GenericRepository<Phone>>();
builder.Services.AddScoped<IItemsService<Phone, PhoneDTO, PhoneSpecifications, PhoneSpecificationsDTO >, 
    ItemsService<Phone, PhoneDTO, PhoneSpecifications, PhoneSpecificationsDTO>>();
builder.Services.AddScoped<IUserService<User, UserDTO>, UserService<User, UserDTO>>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<StoreContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " +
    "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    options.User.RequireUniqueEmail = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "IdentityArea",
        areaName: "Identity",
        pattern: "Identity/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();
