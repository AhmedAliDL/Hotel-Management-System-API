using Application.Auth.Dtos;
using Application.Responses;

namespace Application.Common.Interfaces
{
    public interface IEmailSenderService : IServiceMarker
    {
        Task<ResponseResult<bool>> SendEmailService(string fromEmial, string toEmail, EmailSenderDto contactDto, string plainType);
    }
}
