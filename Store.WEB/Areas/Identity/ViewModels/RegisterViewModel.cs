using System.ComponentModel.DataAnnotations;

namespace Store.Areas.Identity.ViewModels;

public class RegisterViewModel
{
    public string Name { get; set; }

    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}