namespace Store.ViewModels;

public class ItemBase : EntityBaseViewModel
{
    public string Brand { get; set; }

    public uint Price { get; set; }

    public uint Amount { get; set; }

    public byte[]? Image { get; set; }
}