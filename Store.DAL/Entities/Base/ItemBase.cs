using Store.DAL.Entities.ItemProperties;
using Store.DAL.Enums;

namespace Store.DAL.Entities.Base;

public class ItemBase : EntityBase
{
    public int Price { get; set; }

    public int Amount { get; set; }

    public byte[]? Image { get; set; } // temp

    public Brand Brand { get; set; }

    public Model Model { get; set; }
}