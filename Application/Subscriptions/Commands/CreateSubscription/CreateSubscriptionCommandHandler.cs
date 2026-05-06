using Application.Common.Interfaces;
using Application.Common.Mappers;
using Application.Responses;
using Domain.Entities.SubscriptionEntity;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ResponseResult<Guid>>
    {
        public readonly IAppDbContext _context;
        public CreateSubscriptionCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseResult<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.SubscriptionDto.CompanyId, cancellationToken);
            if (company == null)
                return ResponseResult<Guid>.Failure("Company not found.");
            var planDef = PlanCatalog.GetPlanDefinition(request.SubscriptionDto.PlanName);

            var sub = new Subscription
            {
                Id = Guid.NewGuid(),
                PlanName = request.SubscriptionDto.PlanName,
                PlanPrice = planDef.Price,
                MaximumBranches = planDef.MaxBranches,
                MaximumGuests = planDef.MaxGuests,
                StartsAt = DateTime.UtcNow,
                Status = PlanStatus.Active,
                CompanyId = company.Id
            };
            if (sub.PlanName == SubscriptionPlan.Free)
                sub.ExpiresAt = sub.StartsAt.AddYears(1000);
            else
                sub.ExpiresAt = sub.StartsAt.AddMonths(1);
            await _context.Subscriptions.AddAsync(sub, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ResponseResult<Guid>.Success(sub.Id);
        }
    }
}
