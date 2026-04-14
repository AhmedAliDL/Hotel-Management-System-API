using Domain.Entities.BookingServiceEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.BookingServiceConfig
{
    internal class BookingServiceConfig : IEntityTypeConfiguration<BookingService>
    {
        public void Configure(EntityTypeBuilder<BookingService> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(c => c.Booking)
                .WithMany(b => b.BookingServices)
                .HasForeignKey(c => c.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Service)
                .WithMany(s => s.BookingServices)
                .HasForeignKey(c => c.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.CreatedByEmployee)
                .WithMany(e => e.BookingServices)
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(b => !b.IsDeleted);

        }
    }
}
