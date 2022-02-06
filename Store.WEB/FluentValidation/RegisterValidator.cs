using FluentValidation;
using Store.Areas.Identity.ViewModels;
using System.Text.RegularExpressions;

namespace Store.FluentValidation
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Name).NotNull().Must(name => this.NameValidation(name)).WithMessage("It's not a valid Name.");
            RuleFor(u => u.Email).NotNull().EmailAddress().WithMessage("It's not a valid email.");
            RuleFor(u => u.PhoneNumber).NotNull();
            RuleFor(u => u.Password).NotNull().Length(6, 20);
        }

        public bool NameValidation(string name)
        {
            var regex = new Regex("^[а-яa-z]+$", RegexOptions.IgnoreCase);
            return regex.IsMatch(name);
        }
    }
}
