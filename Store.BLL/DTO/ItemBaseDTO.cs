using Store.BLL.DTO.ItemsProperties;

namespace Store.BLL.DTO;

public class ItemBaseDTO : EntityBaseDTO
{
    public int Price { get; set; }

    public int Amount { get; set; }

    public List<ImageDTO> Images { get; set; }

    public BrandDTO Brand { get; set; }

    public ModelDTO Model { get; set; }

    public ColorDTO Color { get; set; }
}