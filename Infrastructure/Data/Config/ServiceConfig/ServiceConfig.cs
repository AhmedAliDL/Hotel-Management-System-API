using Domain.Entities.ServiceEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.ServiceConfig
{
    internal class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(s => s.Company)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Branch)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
