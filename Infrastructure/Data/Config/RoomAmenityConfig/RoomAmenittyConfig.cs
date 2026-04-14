using Domain.Entities.RoomAmenityEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.RoomAmenityConfig
{
    internal class RoomAmenittyConfig : IEntityTypeConfiguration<RoomAmenity>
    {
        public void Configure(EntityTypeBuilder<RoomAmenity> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(ra => ra.Room)
                .WithMany(r => r.RoomAmenities)
                .HasForeignKey(ra => ra.RoomId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ra => ra.Amenity)
                .WithMany(a => a.RoomAmenities)
                .HasForeignKey(ra => ra.AmenityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(r => !r.IsDeleted);
        }
    }
}
