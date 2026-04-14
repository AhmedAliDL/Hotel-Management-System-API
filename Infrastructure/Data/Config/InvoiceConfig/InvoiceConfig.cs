using Domain.Entities.InvoiceEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.InvoiceConfig
{
    internal class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(i => i.Booking)
                .WithOne(b => b.Invoice)
                .HasForeignKey<Invoice>(i => i.BookingId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(i => i.Guest)
                .WithMany(g => g.Invoices)
                .HasForeignKey(i => i.GuestId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(i => i.Branch)
                .WithMany(b => b.Invoices)
                .HasForeignKey(i => i.BranchId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(i => i.Company)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.CreatedByEmployee)
                .WithMany(e => e.Invoices)
                .HasForeignKey(i => i.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(i => !i.IsDeleted);


        }
    }
}
