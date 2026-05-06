using Application.Common.Interfaces;
using Application.Common.Mappers;
using Application.Responses;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subscriptions.Commands.EditSubscription
{
    public class EditSubscriptionCommandHandler : IRequestHandler<EditSubscriptionCommand, ResponseResult<bool>>
    {
        private readonly IAppDbContext _context;
        public EditSubscriptionCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseResult<bool>> Handle(EditSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.EditSubscriptionDto.CompanyId, cancellationToken);
            if (company == null)
                return ResponseResult<bool>.Failure("Company not found.");
            var subscription = await _context.Subscriptions.FirstOrDefaultAsync(s => s.CompanyId == request.EditSubscriptionDto.CompanyId, cancellationToken);
            if (subscription == null)
                return ResponseResult<bool>.Failure("Subscription not found.");
            var subInfo = PlanCatalog.GetPlanDefinition(request.EditSubscriptionDto.PlanName);
            subscription.PlanName = request.EditSubscriptionDto.PlanName;
            subscription.PlanPrice = subInfo.Price;
            subscription.MaximumBranches = subInfo.MaxBranches;
            subscription.MaximumGuests = subInfo.MaxGuests;
            subscription.StartsAt = DateTime.UtcNow;
            if (subscription.PlanName == SubscriptionPlan.Free)
                subscription.ExpiresAt = subscription.StartsAt.AddYears(1000);
            else
                subscription.ExpiresAt = subscription.StartsAt.AddMonths(1);

            await _context.SaveChangesAsync(cancellationToken);
            return ResponseResult<bool>.Success(true);
        }
    }

}
