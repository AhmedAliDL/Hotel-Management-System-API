using Domain.Entities.RoomEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.RoomConfig
{
    internal class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(r => r.Branch)
                .WithMany(b => b.Rooms)
                .HasForeignKey(r => r.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(i => !i.IsDeleted);

        }
    }
}
