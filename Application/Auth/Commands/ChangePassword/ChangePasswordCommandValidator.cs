using FluentValidation;

namespace Application.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(c => c.ChangePasswordDto.UserEmail)
                .NotEmpty()
                .WithMessage("Email field is required")
                .MinimumLength(15)
                .WithMessage("Email must be greater than 15");

        }
    }
    
}
