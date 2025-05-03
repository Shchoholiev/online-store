using Store.DAL.Entities.Base;
using Store.DAL.Entities.Identity;

namespace Store.DAL.Entities.Orders;

public class Order : EntityBase
{
    public IEnumerable<CartItem> Items { get; set; }

    public User User { get; set; }

    public int TotalPrice { get; set; }

    public DeliveryOption Delivery { get; set; }

    public string? DeliveryAddress { get; set; }

    public PaymentOption Payment { get; set; }

    public DateTime CreationTime { get; set; }

    public bool IsPaid { get; set; }

    public string? Details { get; set; }
}