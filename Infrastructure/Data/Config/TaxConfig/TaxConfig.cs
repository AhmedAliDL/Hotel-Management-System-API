using Domain.Entities.TaxConfigEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.TaxConfig
{
    internal class TaxConfig : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(t => t.Branch)
                .WithMany(b => b.Taxes)
                .HasForeignKey(t => t.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(t => !t.IsDeleted);

        }
    }
}
