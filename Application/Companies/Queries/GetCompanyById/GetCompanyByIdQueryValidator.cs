using FluentValidation;

namespace Application.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQueryValidator : AbstractValidator<GetCompanyByIdQuery>
    {
        public GetCompanyByIdQueryValidator()
        {
            RuleFor(c => c.CompanyId)
                .NotEmpty()
                .WithMessage("Company Id is required.");
        }
    }
    
}
