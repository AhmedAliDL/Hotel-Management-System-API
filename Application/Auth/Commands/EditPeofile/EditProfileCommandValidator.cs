using FluentValidation;

namespace Application.Auth.Commands.EditPeofile
{
    public class EditProfileCommandValidator : AbstractValidator<EditProfileCommand>
    {
        public EditProfileCommandValidator()
        {
            RuleFor(e => e.editProfileDto.Email)
                .NotEmpty()
                .WithMessage("Email is required");
            RuleFor(e => e.editProfileDto.Fname)
                .MaximumLength(30)
                .WithMessage("First name must be less than 30")
                .MinimumLength(3)
                .WithMessage("First name must be greater than 3");
            RuleFor(e => e.editProfileDto.Lname)
                .MaximumLength(30)
                .WithMessage("Last name must be less than 30")
                .MinimumLength(3)
                .WithMessage("Last name must be greater than 3");

        }
    }

}
