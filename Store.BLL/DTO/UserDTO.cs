namespace Store.BLL.DTO;

public class UserDTO : EntityBaseDTO
{
    public string Name { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
}