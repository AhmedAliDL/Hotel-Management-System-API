using Application.Common.Interfaces;
using Application.Subscriptions.Dtos;
using Application.Subscriptions.Queries.GetAllActiveSubscription;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subscriptions.Queries.GetAllSubscription
{
    public class GetAllActiveSubscriptionQueryHandler : IRequestHandler<GetAllActiveSubscriptionQuery, List<ActiveSubscriptionInfoDto>>
    {
        private readonly IAppDbContext _context;
        public GetAllActiveSubscriptionQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public Task<List<ActiveSubscriptionInfoDto>> Handle(GetAllActiveSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = _context.Subscriptions
                .Include(s => s.Company)
                .Where(s => s.Status == PlanStatus.Active)
                .Select(
                s => new ActiveSubscriptionInfoDto
                {
                    CompanyName = s.Company.CompanyName,
                    SubscriptionPlan = s.PlanName.ToString(),
                    StartDate = s.StartsAt,
                    ExpireDate = s.ExpiresAt,
                }
                ).ToListAsync();
            return subscriptions;
        }
    }

}
