using Application.Common.Interfaces;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.Register
{
    public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRoleService _roleService;
        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IRoleService roleService)
        {
            _userManager = userManager;
            _roleService = roleService;

        }
        public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser newUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Fname = request.Register.Fname,
                Lname = request.Register.Lname,
                Email = request.Register.Email,
                UserName = request.Register.Email
            };
            var resultOfCreatingUser = await _userManager.CreateAsync(newUser, request.Register.Password);

            if (resultOfCreatingUser.Succeeded)
            {
                string roleName = "User";

                await _roleService.CreateRoleAsync(roleName);
                await _userManager.AddToRoleAsync(newUser, roleName);
            }

            return newUser.Id;
        }
    }

}
