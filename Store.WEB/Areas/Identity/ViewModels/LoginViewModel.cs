using System.ComponentModel.DataAnnotations;

namespace Store.Areas.Identity.ViewModels;

public class LoginViewModel
{
    [Required]
    [StringLength(50, ErrorMessage = "Is it valid login?")]
    [Display(Name = "Phone number or email")]
    public string Login { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; } = false;

    public string ReturnUrl { get; set; }
}