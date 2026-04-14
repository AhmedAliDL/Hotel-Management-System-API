using Domain.Entities.RoomMaintenanceEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.RoomMaintenanceConfig
{
    internal class RoomMaintenanceConfig : IEntityTypeConfiguration<RoomMaintenance>
    {
        public void Configure(EntityTypeBuilder<RoomMaintenance> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(rm => rm.Room)
                .WithMany(r => r.RoomMaintenances)
                .HasForeignKey(rm => rm.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.CreatedByEmployee)
                .WithMany(e => e.RoomMaintenances)
                .HasForeignKey(r => r.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(i => !i.IsDeleted);
        }
    }
}
