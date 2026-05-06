using Application.Common.Interfaces;
using Application.Subscriptions.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subscriptions.Queries.GetAllSubscription
{
    public class GetAllSubscriptionQueryHandler : IRequestHandler<GetAllSubscriptionQuery, List<SubscriptionInfoDto>>
    {
        private readonly IAppDbContext _context;
        public GetAllSubscriptionQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public Task<List<SubscriptionInfoDto>> Handle(GetAllSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = _context.Subscriptions
                .Include(s => s.Company)
                .Select(
                s => new SubscriptionInfoDto
                {
                    CompanyName = s.Company.CompanyName,
                    SubscriptionPlan = s.PlanName.ToString(),
                    StartDate = s.StartsAt,
                    ExpireDate = s.ExpiresAt,
                    PlanStatus = s.Status.ToString()

                }
                ).ToListAsync(cancellationToken: cancellationToken);
            return subscriptions;
        }
    }

}
