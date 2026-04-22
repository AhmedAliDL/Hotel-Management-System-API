using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.Register
{
    public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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

                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(
                        new IdentityRole<Guid>
                        {
                            Name = roleName
                        }
                        );
                }
                await _userManager.AddToRoleAsync(newUser, roleName);
            }

            return newUser.Id;
        }
    }

}
