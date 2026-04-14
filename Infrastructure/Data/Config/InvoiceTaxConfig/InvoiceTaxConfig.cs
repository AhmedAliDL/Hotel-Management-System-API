using Domain.Entities.InvoiceTaxEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.InvoiceTaxConfig
{
    internal class InvoiceTaxConfig : IEntityTypeConfiguration<InvoiceTax>
    {
        public void Configure(EntityTypeBuilder<InvoiceTax> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(it => it.Invoice)
                .WithMany(i => i.InvoiceTaxes)
                .HasForeignKey(it => it.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(it => it.Tax)
                .WithMany(t => t.InvoiceTaxes)
                .HasForeignKey(it => it.TaxConfigId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(i => !i.IsDeleted);
        }
    }
}
