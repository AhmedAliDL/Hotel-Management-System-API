using Application.Auth.Commands.ChangePassword;
using Application.Auth.Commands.ConfirmEmailToken;
using Application.Auth.Commands.EditPeofile;
using Application.Auth.Commands.EmailConfirm;
using Application.Auth.Commands.Login;
using Application.Auth.Commands.Logout;
using Application.Auth.Commands.RefreshToken;
using Application.Auth.Commands.Register;
using Application.Auth.Commands.ResetPassword;
using Application.Auth.Commands.SendPasswordResetToken;
using Application.Auth.Dtos;
using Application.Auth.Queries.Profile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> Profile([FromBody] string email)
        {
            var result = await _mediator.Send(new GetUserProfileQuery(email));
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpPost("EditProfile")]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDto editProfileDto)
        {
            var result = await _mediator.Send(new EditProfileCommand(editProfileDto));
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {

            return Ok(await _mediator.Send(new RegisterCommand(registerDto)));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _mediator.Send(new LoginCommand(loginDto));
            if (!result.IsSuccess)
                return BadRequest(result);
            if (!string.IsNullOrEmpty(result.Value!.RefreshToken))
                SetRefreshTokenInCookie(result.Value.RefreshToken, result.Value.RefreshTokenExpiration);
            return Ok(result);
        }
        [HttpPost("RefreshToken")]
        [Authorize]
        public async Task<IActionResult> RefreshToken()
        {
            var result = await _mediator.Send(new RefreshTokenCommand(Request.Cookies["RefreshToken"]!));
            if (!result.IsSuccess)
                return BadRequest(result);
            SetRefreshTokenInCookie(result.Value!.RefreshToken!, result.Value.RefreshTokenExpiration);
            return Ok(result);
        }
        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var result = await _mediator.Send(new LogoutCommand(Request.Cookies["RefreshToken"]!));
            if (!result.IsSuccess)
                return BadRequest(result);
            Response.Cookies.Delete("RefreshToken");
            return Ok(result);
        }
        [HttpPost("SendEmailConfirmationToken")]
        public async Task<IActionResult> SendEmailConfirmationToken([FromBody] string userEmail)
        {
            var result = await _mediator.Send(new SendEmailConfirmationTokenCommand(userEmail));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("ConfirmEmailToken")]
        public async Task<IActionResult> ConfirmEmailToken([FromBody] ConfirmEmailDto confirmEmailDto)
        {
            var result = await _mediator.Send(new ConfirmEmailTokenCommand(confirmEmailDto));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _mediator.Send(new ChangePasswordCommand(changePasswordDto));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("SendPasswordResetToken")]
        public async Task<IActionResult> SendPasswordResetToken([FromBody] string userEmail)
        {
            var result = await _mediator.Send(new SendPasswordResetTokenCommand(userEmail));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var result = await _mediator.Send(new ResetPasswordCommand(resetPasswordDto));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
            };
            Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);

        }
    }
}


