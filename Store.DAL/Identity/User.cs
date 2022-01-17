using Microsoft.AspNetCore.Identity;
using Store.DAL.Entities.Order;

namespace Store.DAL.Identity;

public class User : IdentityUser
{
    public List<Order>? Orders { get; set; }
}