using Application.Common.Interfaces;
using Application.Companies.Dtos;
using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, ResponseResult<CompanyDto>>
    {
        private readonly IAppDbContext _context;
        public GetCompanyByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseResult<CompanyDto>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == request.CompanyId, cancellationToken);

            if (company == null)
                return ResponseResult<CompanyDto>.Failure("Company not found.");

            var response = new CompanyDto
            {
                UserEmail = company.User.Email!,
                CompanyName = company.CompanyName,
                Country = company.Country,
                Address = company.Address,
                City = company.City
            };
            return ResponseResult<CompanyDto>.Success(response);
        }
    }

}
