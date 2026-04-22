using Application.Auth.Dtos;
using Application.Common.Interfaces;
using Application.Responses;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
namespace Infrastructure.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _configuration;
        public EmailSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ResponseResult<bool>> SendEmailService(string fromEmial, string toEmail, EmailSenderDto contactDto, string plainType = "plain")
        {
            string adminEmail = _configuration["SmtpSettings:AdminEmail"]!;

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Hotel Management System Website", adminEmail));// brevo server email

            message.To.Add(new MailboxAddress("Admin", toEmail)); // to email address

            message.ReplyTo.Add(new MailboxAddress("User", fromEmial)); // from email address

            message.Subject = contactDto.Subject;


            message.Body = new TextPart(plainType)
            {
                Text = contactDto.Body
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(
                        host: _configuration["SmtpSettings:SmtpServer"]!,
                        port: int.Parse(_configuration["SmtpSettings:Port"]!),
                        MailKit.Security.SecureSocketOptions.StartTls
                        );
                    var userName = _configuration["SmtpSettings:SmtpEmail"]!;
                    var emailPassword = _configuration["SmtpSettings:Password"]!;

                    await client.AuthenticateAsync(userName, emailPassword);
                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }
                catch
                {
                    return ResponseResult<bool>.Failure("Error happend when sending message");
                }
            }

            return ResponseResult<bool>.Success(true);
        }


    }
}
