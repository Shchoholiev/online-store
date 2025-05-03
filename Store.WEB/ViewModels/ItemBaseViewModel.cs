namespace Store.ViewModels;

public class ItemBaseViewModel : EntityBaseViewModel
{
    public string Brand { get; set; }

    public string Model { get; set; }

    public int Price { get; set; }

    public int Amount { get; set; }

    public string Image { get; set; }

    public virtual string GetFullName()
    {
        return $"{Brand} {Model}";
    }
}