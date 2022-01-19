using System.ComponentModel.DataAnnotations;

namespace Store.Areas.Identity.ViewModels;

public class RegisterViewModel
{
    [Required (ErrorMessage = "Type your name.")]
    [StringLength(20, ErrorMessage = "The name cannot be longer than 20 characters.")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Phone Number")]
    [Phone]
    public string PhoneNumber { get; set; }

    [StringLength(50, ErrorMessage = "Is it valid email?")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}