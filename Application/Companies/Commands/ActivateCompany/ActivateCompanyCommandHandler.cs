using Application.Common.Interfaces;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.ActivateCompany
{
    public class ActivateCompanyCommandHandler : IRequestHandler<ActivateCompanyCommand, ResponseResult<bool>>
    {
        private readonly IAppDbContext _context;
        public ActivateCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;   
        }

        public async Task<ResponseResult<bool>> Handle(ActivateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.CompanyId);
            if (company == null)
                return ResponseResult<bool>.Failure("Company not found.");
            company.IsActive = true;
            await _context.SaveChangesAsync(cancellationToken);
            return ResponseResult<bool>.Success(true);
        }
    }
    
}
