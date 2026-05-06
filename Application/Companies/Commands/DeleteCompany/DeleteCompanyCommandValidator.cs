using FluentValidation;

namespace Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(e => e.CompanyId)
               .NotEmpty()
               .WithMessage("Company Id should not be empty");
        }
    }

}
