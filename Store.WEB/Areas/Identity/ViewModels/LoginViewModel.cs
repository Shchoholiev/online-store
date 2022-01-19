using System.ComponentModel.DataAnnotations;

namespace Store.Areas.Identity.ViewModels;

public class LoginViewModel
{
    [Required]
    [StringLength(50, ErrorMessage = "Is it valid login?")]
    [Display(Name = "Phone number or email")]
    public string Login { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; } = false;

    public string ReturnUrl { get; set; }
}