using Store.DAL.DataInitializer;
using Store.DAL.EF;

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
    }
}
