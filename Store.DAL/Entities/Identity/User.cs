using Microsoft.AspNetCore.Identity;
using Store.DAL.Entities.Orders;


namespace Store.DAL.Entities.Identity;

public class User : IdentityUser
{
    public List<Order>? Orders { get; set; }
}