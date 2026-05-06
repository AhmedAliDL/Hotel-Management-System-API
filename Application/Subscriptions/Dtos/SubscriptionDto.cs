using Domain.Enums;
using System.Text.Json.Serialization;

namespace Application.Subscriptions.Dtos
{
    public class SubscriptionDto
    {
        [JsonIgnore]
        public Guid CompanyId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SubscriptionPlan PlanName { get; set; }
    }
}
