using Domain.Entities.InvoiceItemsEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.InvoiceItemsConfig
{
    internal class InvoiceItemsConfig : IEntityTypeConfiguration<InvoiceItems>
    {
        public void Configure(EntityTypeBuilder<InvoiceItems> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(ii => ii.Invoice)
                .WithMany(i => i.InvoiceItems)
                .HasForeignKey(ii => ii.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.CreatedByEmployee)
                .WithMany(e => e.InvoiceItems)
                .HasForeignKey(i => i.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(i => !i.IsDeleted);

        }
    }
}
