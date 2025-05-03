using Store.DAL.Entities.ItemProperties;

namespace Store.DAL.Entities.Base;

public class ItemBase : EntityBase
{
    public int Price { get; set; }

    public int Amount { get; set; }

    public Image? Image { get; set; }

    public Brand? Brand { get; set; }

    public Model? Model { get; set; }

    public Color? Color { get; set; }
}