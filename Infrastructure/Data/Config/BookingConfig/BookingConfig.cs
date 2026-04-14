using Domain.Entities.BookingEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.BookingConfig
{
    internal class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(b => b.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GuestId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.Branch)
                .WithMany(br => br.Bookings)
                .HasForeignKey(b => b.BranchId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.CreatedByEmployee)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
