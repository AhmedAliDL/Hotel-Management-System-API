using Domain.Entities.BookingRoomEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.BookingRoomConfig
{
    internal class BookingRoomConfig : IEntityTypeConfiguration<BookingRoom>
    {
        public void Configure(EntityTypeBuilder<BookingRoom> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(b => b.Booking)
                .WithMany(bk => bk.BookingRooms)
                .HasForeignKey(b => b.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.Room)
                .WithMany(r => r.BookingRooms)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
