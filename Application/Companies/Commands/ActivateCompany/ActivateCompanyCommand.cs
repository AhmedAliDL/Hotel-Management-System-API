using Application.Responses;
using MediatR;

namespace Application.Companies.Commands.ActivateCompany
{
    public record ActivateCompanyCommand(Guid CompanyId) : IRequest<ResponseResult<bool>>;

}
