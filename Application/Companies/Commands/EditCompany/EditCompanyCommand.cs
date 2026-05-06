using Application.Companies.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Companies.Commands.EditCompany
{
    public record EditCompanyCommand(Guid CompanyId, EditCompanyDto EditCompanyDto) : IRequest<ResponseResult<bool>>;

}
