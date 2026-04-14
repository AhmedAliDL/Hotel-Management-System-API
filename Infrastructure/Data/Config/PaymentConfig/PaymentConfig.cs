using Domain.Entities.PaymentEntity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config.PaymentConfig
{
    internal class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(p => p.Invoice)
                .WithMany(i => i.Payments)
                .HasForeignKey(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Company)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.CreatedByEmployee)
                .WithMany(e => e.Payments)
                .HasForeignKey(p => p.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(i => !i.IsDeleted);
        }
    }
}
