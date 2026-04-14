using Domain.Entities.BlackListEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.BlackListConfig
{
    internal class BlackListConfig : IEntityTypeConfiguration<BlackList>
    {
        public void Configure(EntityTypeBuilder<BlackList> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(b => b.Company)
                .WithMany(c => c.BlackLists)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.Guest)
                .WithOne(g => g.BlackList)
                .HasForeignKey<BlackList>(b => b.GuestId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(b => b.Branch)
                .WithMany(br => br.BlackLists)
                .HasForeignKey(b => b.BranchId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(b => b.CreatedByEmployee)
                .WithMany(e => e.BlackLists)
                .HasForeignKey(b => b.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(b => !b.IsDeleted);

        }
    }
}
