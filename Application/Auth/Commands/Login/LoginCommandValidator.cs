using FluentValidation;


namespace Application.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.LoginDto.Email)
                .NotEmpty()
                .WithMessage("Email field is required");
            RuleFor(l => l.LoginDto.Password)
                .NotEmpty()
                .WithMessage("Password field is required");

        }
    }

}
