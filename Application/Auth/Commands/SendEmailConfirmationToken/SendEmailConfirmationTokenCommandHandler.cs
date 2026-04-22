using Application.Auth.Dtos;
using Application.Common.Interfaces;
using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Application.Auth.Commands.EmailConfirm
{
    public class SendEmailConfirmationTokenCommandHandler : IRequestHandler<SendEmailConfirmationTokenCommand, ResponseResult<bool>>
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public SendEmailConfirmationTokenCommandHandler(IEmailSenderService emailSenderService, UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _emailSenderService = emailSenderService;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ResponseResult<bool>> Handle(SendEmailConfirmationTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.userEmail);
            if (user == null)
            {
                ResponseResult<bool>.Failure("User not found!");
            }
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user!);

            return await _emailSenderService.SendEmailService(
                  _configuration["SmtpSettings:AdminEmail"]!,
                user!.Email!,
                new EmailSenderDto
                {
                    Subject = "Email Confirmation Code",
                    Body = $"Your confirmation code is: {token}"
                },
                "Plain"
                );

        }
    }
}
