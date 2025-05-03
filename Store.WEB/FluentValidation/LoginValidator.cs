using FluentValidation;
using Store.Areas.Identity.ViewModels;

namespace Store.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Login).NotNull().Length(0, 50);
            RuleFor(u => u.Password).NotNull().Length(6, 20);
        }
    }
}
