namespace Store.BLL.DTO;

public class ItemBaseDTO : EntityBaseDTO
{
    public int Price { get; set; }

    public int Amount { get; set; }

    public string Image { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string Color { get; set; }

    public string ColorHex { get; set; }
}