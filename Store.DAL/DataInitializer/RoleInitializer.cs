using Microsoft.AspNetCore.Identity;
using Store.DAL.Entities.Identity;

namespace Store.DAL.DataInitializer
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@gmail.com";
            var adminPhone = "1111";
            var adminPassword = "123456";

            await roleManager.CreateAsync(new IdentityRole("admin"));

            var admin = new User { Name = "admin", Email = adminEmail, PhoneNumber = adminPhone, UserName = "admin" };
            var result = await userManager.CreateAsync(admin, adminPassword);
            await userManager.AddToRoleAsync(admin, "admin");
        }
    }
}
