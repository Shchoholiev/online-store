using Microsoft.AspNetCore.Identity;
using Store.DAL.DataInitializer;
using Store.DAL.EF;
using Store.DAL.Entities.Identity;

namespace Store.BLL.DbInitialization
{
    public class DbInitializerBLL
    {
        public void DeleteAndInitialize()
        {
            using (var context = new StoreContext())
            {
                DbInitializer.Delete(context);
                DbInitializer.Initialize(context);
            }
        }

        public async Task InitializeRoles(IServiceProvider services)
        {
            var userManager = (UserManager<User>)services.GetService(typeof(UserManager<User>));
            var roleManager = (RoleManager<IdentityRole>)services.GetService(typeof(RoleManager<IdentityRole>));
            await RoleInitializer.InitializeAsync(userManager, roleManager);
        }
    }
}
