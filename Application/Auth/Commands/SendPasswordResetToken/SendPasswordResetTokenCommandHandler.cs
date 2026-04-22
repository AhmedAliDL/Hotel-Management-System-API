using Application.Auth.Dtos;
using Application.Common.Interfaces;
using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Application.Auth.Commands.SendPasswordResetToken
{
    public class SendPasswordResetTokenCommandHandler : IRequestHandler<SendPasswordResetTokenCommand,ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IConfiguration _configuration;
        public SendPasswordResetTokenCommandHandler(UserManager<ApplicationUser> userManager, IEmailSenderService emailSenderService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _emailSenderService = emailSenderService;
            _configuration = configuration;
        }

        public async Task<ResponseResult<bool>> Handle(SendPasswordResetTokenCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(request.email);
            if (user == null)
                return ResponseResult<bool>.Failure("User not found");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return await _emailSenderService.SendEmailService(
                  _configuration["SmtpSettings:AdminEmail"]!,
                user!.Email!,
                new EmailSenderDto
                {
                    Subject = "Reset Password Code",
                    Body = $"Your confirmation code is: {token}"
                },
                "Plain"
                );
        }
    }


}
