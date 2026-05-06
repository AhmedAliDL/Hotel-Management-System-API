using Application.Companies.Dtos;
using MediatR;

namespace Application.Companies.Queries.ShowAllCompaniesInSystem
{
    public record GetAllCompaniesInSystemQuery : IRequest<List<CompanyDto>>;


}
