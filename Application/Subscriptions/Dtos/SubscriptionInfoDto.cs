namespace Application.Subscriptions.Dtos
{
    public class SubscriptionInfoDto
    {
        public string CompanyName { get; set; }
        public string SubscriptionPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string PlanStatus { get; set; }

    }
}
