using Domain.Entities.AmenityEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.AmenityConfig
{
    internal class AmenityConfig : IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(a => a.Company)
                .WithMany(c => c.Amenities)
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Branch)
                .WithMany(b => b.Amenities)
                .HasForeignKey(a => a.BranchId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}
