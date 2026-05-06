using FluentValidation;

namespace Application.Companies.Commands.ActivateCompany
{
    public class ActivateCompanyCommandValidator : AbstractValidator<ActivateCompanyCommand>
    {
        public ActivateCompanyCommandValidator()
        {
            RuleFor(e => e.CompanyId)
               .NotEmpty()
               .WithMessage("Company Id should not be empty");
        }
    }

}
