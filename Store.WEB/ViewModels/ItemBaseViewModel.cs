using Store.ViewModels.ItemsProperties;

namespace Store.ViewModels;

public class ItemBaseViewModel : EntityBaseViewModel
{
    public string Brand { get; set; }

    public string Model { get; set; }

    public int Price { get; set; }

    public int Amount { get; set; }

    public List<ImageViewModel> Images { get; set; }

    public string Color { get; set; }

    public string ColorHex { get; set; }

    public virtual string GetFullName()
    {
        return $"{Brand} {Model}";
    }
}