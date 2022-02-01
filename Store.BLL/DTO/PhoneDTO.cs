namespace Store.BLL.DTO;

public class PhoneDTO : ItemBaseDTO
{   
    public ushort Memory { get; set; }
    
    public string Color { get; set; }
    
    public string ColorHex { get; set; }
    
    public PhoneSpecificationsDTO Specifications { get; set; }
}