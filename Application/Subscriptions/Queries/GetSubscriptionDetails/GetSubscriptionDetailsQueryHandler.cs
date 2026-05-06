using Application.Common.Interfaces;
using Application.Responses;
using Application.Subscriptions.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Subscriptions.Queries.GetSubscriptionDetails
{
    public class GetSubscriptionDetailsQueryHandler : IRequestHandler<GetSubscriptionDetailsQuery, ResponseResult<SubscriptionInfoDto>>
    {
        private readonly IAppDbContext _context;
        public GetSubscriptionDetailsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseResult<SubscriptionInfoDto>> Handle(GetSubscriptionDetailsQuery request, CancellationToken cancellationToken)
        {
            var sub = await _context.Subscriptions
                .Include(s => s.Company)
                .FirstOrDefaultAsync(s => s.CompanyId == request.CompanyId);
            if (sub == null)
                return ResponseResult<SubscriptionInfoDto>.Failure("Subscription not found for the given company.");
            return ResponseResult<SubscriptionInfoDto>.Success(new SubscriptionInfoDto
            {
                CompanyName = sub.Company.CompanyName,
                SubscriptionPlan = sub.PlanName.ToString(),
                StartDate = sub.StartsAt,
                ExpireDate = sub.ExpiresAt,
                PlanStatus = sub.Status.ToString()
            });
        }
    }

}
