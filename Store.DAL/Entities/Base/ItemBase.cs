using Store.DAL.Entities.EntitiesForEnums;
using Store.DAL.Enums;

namespace Store.DAL.Entities.Base;

public class ItemBase : EntityBase
{
    public int Price { get; set; }

    public int Amount { get; set; }

    public byte[]? Image { get; set; } // temp

    public BrandId BrandId { get; set; }

    public Brand Brand { get; set; }
}