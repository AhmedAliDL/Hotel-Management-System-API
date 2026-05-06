using FluentValidation;

namespace Application.Auth.Commands.Logout
{
    public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(l => l.RefreshToken)
                .NotEmpty()
                .WithMessage("You must enter RefreshToken");
        }
    }

}
