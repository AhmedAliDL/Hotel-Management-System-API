using Application.Companies.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Companies.Queries.GetCompanyById
{
    public record GetCompanyByIdQuery(Guid CompanyId) : IRequest<ResponseResult<CompanyDto>>;

}
