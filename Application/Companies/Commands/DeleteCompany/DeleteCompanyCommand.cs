using Application.Responses;
using MediatR;

namespace Application.Companies.Commands.DeleteCompany
{
    public record DeleteCompanyCommand(Guid CompanyId) : IRequest<ResponseResult<bool>>;

}
