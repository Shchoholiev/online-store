namespace Store.BLL.DTO;

public class ItemBaseDTO : EntityBaseDTO
{
    public uint Price { get; set; }

    public uint Amount { get; set; }

    public byte[]? Image { get; set; }
}