using Domain.Entities.SystemEmployeeEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.SystemEmployeeConfig
{
    internal class SystemEmployeeConfig : IEntityTypeConfiguration<SystemEmployee>
    {
        public void Configure(EntityTypeBuilder<SystemEmployee> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasDefaultValueSql("NEWID()");


            builder.HasOne(s => s.Company)
                .WithMany(c => c.SystemEmployees)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Branch)
                .WithMany(b => b.SystemEmployees)
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(s => s.User)
                .WithMany(u => u.SystemEmployees)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(i => !i.IsDeleted);




        }
    }
}
