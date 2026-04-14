using Domain.Entities.RoomTypeEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.RoomTypeConfig
{
    internal class RoomTypeConfig : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(r => r.Company)
                .WithMany(c => c.RoomTypes)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.Branch)
                .WithMany(c => c.RoomTypes)
                .HasForeignKey(r => r.BranchId)
                .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
