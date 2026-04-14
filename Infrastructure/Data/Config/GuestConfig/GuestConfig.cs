using Domain.Entities.GuestEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.GuestConfig
{
    internal class GuestConfig : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(g => g.Company)
                .WithMany(c => c.Guests)
                .HasForeignKey(g => g.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(g => g.CreatedByEmployee)
                .WithMany(e => e.Guests)
                .HasForeignKey(g => g.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(g => !g.IsDeleted);
        }
    }
}
