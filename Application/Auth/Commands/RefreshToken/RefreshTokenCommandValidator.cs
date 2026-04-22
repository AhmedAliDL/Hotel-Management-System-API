using FluentValidation;

namespace Application.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(rt => rt.refreshToken)
                .NotEmpty()
                .WithMessage("RefreshToken must be included.");
        }

    }

}
