using FluentValidation;

namespace Application.Auth.Queries.Profile
{
    public class GetProfileQueryValidator : AbstractValidator<GetUserProfileQuery>
    {
        public GetProfileQueryValidator()
        {
            RuleFor(p => p.email)
                .NotEmpty()
                .WithMessage("Email should not be empty");

        }
    }
    
}
