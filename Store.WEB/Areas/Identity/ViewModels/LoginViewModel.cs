using System.ComponentModel.DataAnnotations;

namespace Store.Areas.Identity.ViewModels;

public class LoginViewModel
{
    [Display(Name = "Phone number or email")]
    public string Login { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; } = false;

    public string ReturnUrl { get; set; }
}