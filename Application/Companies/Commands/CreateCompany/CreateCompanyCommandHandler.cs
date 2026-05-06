using Application.Common.Interfaces;
using Application.Responses;
using Domain.Entities.CompanyEntity;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ResponseResult<Guid>>
    {
        private readonly IAppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRoleService _roleService;
        public CreateCompanyCommandHandler(IAppDbContext context, UserManager<ApplicationUser> userManager, IRoleService roleService)
        {
            _context = context;
            _userManager = userManager;
            _roleService = roleService;
        }
        public async Task<ResponseResult<Guid>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.CompanyDto.UserEmail!);
            if (user == null)
                return ResponseResult<Guid>.Failure("User not found.");
            var checkCompany = await _context.Companies.FirstOrDefaultAsync(c => c.UserId == user.Id, cancellationToken);
            if (checkCompany != null)
                return ResponseResult<Guid>.Failure("User already has a company.");
            var company = new Company
            {
                Id = Guid.NewGuid(),
                CompanyName = request.CompanyDto.CompanyName,
                Country = request.CompanyDto.Country,
                City = request.CompanyDto.City,
                Address = request.CompanyDto.Address,
                UserId = user.Id,
            };

            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync(cancellationToken);

            string roleName = "CompanyAdmin";
            await _roleService.CreateRoleAsync(roleName);
            await _userManager.AddToRoleAsync(user, roleName);
            await _userManager.RemoveFromRoleAsync(user, "User");


            return ResponseResult<Guid>.Success(company.Id);

        }
    }



}
