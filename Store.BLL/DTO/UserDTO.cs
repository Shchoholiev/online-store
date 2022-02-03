using Microsoft.AspNetCore.Identity;

namespace Store.BLL.DTO;

public class UserDTO : EntityBaseDTO
{
    public string? Name { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? Email { get; set; }
}