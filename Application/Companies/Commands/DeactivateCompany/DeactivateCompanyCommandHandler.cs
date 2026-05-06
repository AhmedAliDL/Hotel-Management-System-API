using Application.Common.Interfaces;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.DeactivateCompany
{
    public class DeactivateCompanyCommandHandler : IRequestHandler<DeactivateCompanyCommand, ResponseResult<bool>>
    {
        private readonly IAppDbContext _context;
        public DeactivateCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseResult<bool>> Handle(DeactivateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.CompanyId);
            if (company == null)
                return ResponseResult<bool>.Failure("Company not found.");
            company.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);
            return ResponseResult<bool>.Success(true);
        }
    }

}
