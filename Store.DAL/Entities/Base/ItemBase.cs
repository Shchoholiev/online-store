namespace Store.DAL.Entities.Base;

public class ItemBase : EntityBase
{
    public uint Price { get; set; }

    public uint Amount { get; set; }

    public byte[]? Image { get; set; }
}