namespace Store.ViewModels;

public class ItemBaseViewModel : EntityBaseViewModel
{
    public string Brand { get; set; }

    public string Model { get; set; }

    public uint Price { get; set; }

    public uint Amount { get; set; }

    public string Image { get; set; }
}