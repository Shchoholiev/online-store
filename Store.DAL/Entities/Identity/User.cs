using Microsoft.AspNetCore.Identity;
using Store.DAL.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace Store.DAL.Entities.Identity;

public class User : IdentityUser<int>
{
    public List<Order>? Orders { get; set; }

    public List<CartItem>? CartItems { get; set; }
}