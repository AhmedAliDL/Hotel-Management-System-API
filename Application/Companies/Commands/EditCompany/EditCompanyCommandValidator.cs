using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.EditCompany
{
    public class EditCompanyCommandValidator : AbstractValidator<EditCompanyCommand>
    {
        private readonly IAppDbContext _context;
        public EditCompanyCommandValidator(IAppDbContext context)
        {
            _context = context;

            RuleFor(c => c.EditCompanyDto.CompanyName)
                .MinimumLength(2)
                .WithMessage("Company name must be bigger than 2")
                .MaximumLength(20)
                .WithMessage("Company name must be less than 20");
            RuleFor(c => c.EditCompanyDto)
                .MustAsync(async (companyDto, cancellationToken) =>
                {
                    bool result = await _context.Companies.AnyAsync(c => c.CompanyName == companyDto.CompanyName);
                    return !result;
                })
                .WithMessage("Company name must be unique");
            RuleFor(c => c.EditCompanyDto.Country)
              .IsInEnum()
              .WithMessage("Country is not defined in our reigon!");
            RuleFor(c => c.EditCompanyDto.City)
                .IsInEnum()
                .WithMessage("City is not defined in our reigon!");
            RuleFor(c => c.EditCompanyDto)
                .Must(dto =>
                       CountryCityMapper.Map.TryGetValue(dto.Country, out var cities)
                       && cities.Contains(dto.City))
            .WithMessage("City does not belong to selected country");
            RuleFor(c => c.EditCompanyDto.Address)
             .MinimumLength(8)
             .WithMessage("Company address must be bigger than 8")
             .MaximumLength(40)
             .WithMessage("Company address must be less than 40");

        }
    }

}
