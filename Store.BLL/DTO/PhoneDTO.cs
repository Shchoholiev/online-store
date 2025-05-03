namespace Store.BLL.DTO;

public class PhoneDTO : ItemBaseDTO
{   
    public ushort Memory { get; set; }
    
    public PhoneSpecificationsDTO Specifications { get; set; }
}