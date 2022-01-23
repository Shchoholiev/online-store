namespace Store.DAL.Entities.Base;

public class ItemBase : EntityBase
{
    public int Price { get; set; }

    public int Amount { get; set; }

    public byte[]? Image { get; set; }
}