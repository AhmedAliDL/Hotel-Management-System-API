using Domain.Entities.User;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterCommandValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            RuleFor(r => r.Register)
                .MustAsync(async (register, cancellation) =>
                {
                    var user = await _userManager.FindByEmailAsync(register.Email);
                    return user == null;
                })
                .WithMessage("Email already exists.");
        }
    }
}
