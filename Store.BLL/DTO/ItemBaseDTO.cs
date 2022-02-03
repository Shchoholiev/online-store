namespace Store.BLL.DTO;

public class ItemBaseDTO : EntityBaseDTO
{
    public uint Price { get; set; }

    public uint Amount { get; set; }

    public string Image { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string Color { get; set; }

    public string ColorHex { get; set; }
}