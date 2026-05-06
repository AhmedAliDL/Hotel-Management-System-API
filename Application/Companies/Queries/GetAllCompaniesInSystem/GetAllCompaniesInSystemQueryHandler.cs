using Application.Common.Interfaces;
using Application.Companies.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Queries.ShowAllCompaniesInSystem
{
    public class GetAllCompaniesInSystemQueryHandler : IRequestHandler<GetAllCompaniesInSystemQuery, List<CompanyDto>>
    {
        private readonly IAppDbContext _context;
        public GetAllCompaniesInSystemQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyDto>> Handle(GetAllCompaniesInSystemQuery request, CancellationToken cancellationToken)
        {
            var listOfCompanies = await _context.Companies
                .Include(c => c.User)
                .Select(c => new CompanyDto
                {
                    CompanyName = c.CompanyName,
                    Address = c.Address,
                    City = c.City,
                    Country = c.Country,
                    UserEmail = c.User.Email!
                }).ToListAsync(cancellationToken);
            return listOfCompanies;

        }
    }


}
