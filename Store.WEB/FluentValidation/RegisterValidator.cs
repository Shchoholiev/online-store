using FluentValidation;
using Store.Areas.Identity.ViewModels;

namespace Store.FluentValidation
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Name).NotNull();
            RuleFor(u => u.Email).NotNull().EmailAddress().WithMessage("It's not a valid email.");
            RuleFor(u => u.PhoneNumber).NotNull();
            RuleFor(u => u.Password).NotNull().Length(6, 20);
        }
    }
}
