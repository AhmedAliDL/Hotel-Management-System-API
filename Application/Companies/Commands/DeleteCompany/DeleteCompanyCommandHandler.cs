using Application.Common.Interfaces;
using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, ResponseResult<bool>>
    {
        private readonly IAppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DeleteCompanyCommandHandler(IAppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.CompanyId, cancellationToken);
            if (company == null)
                return ResponseResult<bool>.Failure("Company not found.");
            var user = await _userManager.FindByIdAsync(company.UserId.ToString());
            await _userManager.RemoveFromRoleAsync(user!, "CompanyAdmin");
            await _userManager.AddToRoleAsync(user!, "User");
            await _userManager.UpdateAsync(user!);
            company.IsDeleted = true;
            company.DeletedDate = DateTime.UtcNow;
            company.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);


            return ResponseResult<bool>.Success(true);
        }
    }

}
