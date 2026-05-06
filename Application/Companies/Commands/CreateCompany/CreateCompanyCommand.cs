using Application.Companies.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Companies.Commands.CreateCompany
{
    public record CreateCompanyCommand(CompanyDto CompanyDto) : IRequest<ResponseResult<Guid>>;



}
