using Domain.Entities.SubscriptionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.SubscriptionConfig
{
    internal class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(s => s.Company)
                .WithMany(c => c.Subscriptions)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(i => !i.IsDeleted);
        }
    }
}
