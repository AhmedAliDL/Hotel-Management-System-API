using Application.Common.Interfaces;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.EditCompany
{
    public class EditCompanyCommandHandler : IRequestHandler<EditCompanyCommand, ResponseResult<bool>>
    {
        private readonly IAppDbContext _context;
        public EditCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseResult<bool>> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.CompanyId, cancellationToken);
            if (company == null)
                return ResponseResult<bool>.Failure("Company not found.");
            company.CompanyName = request.EditCompanyDto.CompanyName ?? company.CompanyName;
            company.Country = request.EditCompanyDto.Country ?? company.Country;
            company.City = request.EditCompanyDto.City ?? company.City;
            company.Address = request.EditCompanyDto.Address ?? company.Address;
            company.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseResult<bool>.Success(true);
        }
    }

}
