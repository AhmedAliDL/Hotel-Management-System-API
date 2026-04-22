using FluentValidation;

namespace Application.Auth.Commands.Logout
{
    public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(l => l.refreshToken)
                .NotEmpty()
                .WithMessage("You must enter RefreshToken");
        }
    }

}
