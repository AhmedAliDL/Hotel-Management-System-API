using Application.Responses;
using MediatR;

namespace Application.Companies.Commands.DeactivateCompany
{
    public record DeactivateCompanyCommand(Guid CompanyId) : IRequest<ResponseResult<bool>>;

}
