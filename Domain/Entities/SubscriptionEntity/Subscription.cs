using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Enums;

namespace Domain.Entities.SubscriptionEntity
{
    public class Subscription : ISoftDeletable
    {
        public Guid Id { get; set; }
        public SubscriptionPlan PlanName { get; set; }
        public int MaximumBranches { get; set; }
        public int MaximumGuests { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public PlanStatus Status { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

    }
}
