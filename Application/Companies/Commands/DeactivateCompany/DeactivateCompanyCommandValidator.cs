using Application.Companies.Commands.ActivateCompany;
using FluentValidation;

namespace Application.Companies.Commands.DeactivateCompany
{
    public class DeactivateCompanyCommandValidator : AbstractValidator<ActivateCompanyCommand>
    {
        public DeactivateCompanyCommandValidator()
        {
            RuleFor(e => e.CompanyId)
               .NotEmpty()
               .WithMessage("Company Id should not be empty");
        }
    }

}
