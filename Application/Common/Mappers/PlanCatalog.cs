using Domain.Enums;

namespace Application.Common.Mappers
{
    public static class PlanCatalog
    {
        private static readonly Dictionary<SubscriptionPlan, PlanDefinition> _plans = new()
        {
            {
                SubscriptionPlan.Free , new(0,1, 10)
            },
            {
                SubscriptionPlan.Standard , new(150.23,5,1000)
            },
            {
                SubscriptionPlan.Premium, new(250.50,100,1000000)
            }


        };
        public static PlanDefinition GetPlanDefinition(SubscriptionPlan plan) => _plans[plan];
    }
    public record PlanDefinition(double Price, int MaxBranches, int MaxGuests);
}
