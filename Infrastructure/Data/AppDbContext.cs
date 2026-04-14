using Domain.Entities.AmenityEntity;
using Domain.Entities.BlackListEntity;
using Domain.Entities.BookingEntity;
using Domain.Entities.BookingRoomEntity;
using Domain.Entities.BookingServiceEntity;
using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.GuestEntity;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.InvoiceItemsEntity;
using Domain.Entities.InvoiceTaxEntity;
using Domain.Entities.PaymentEntity;
using Domain.Entities.RoomAmenityEntity;
using Domain.Entities.RoomEntity;
using Domain.Entities.RoomMaintenanceEntity;
using Domain.Entities.RoomTypeEntity;
using Domain.Entities.ServiceEntity;
using Domain.Entities.SubscriptionEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Entities.TaxConfigEntity;
using Domain.Entities.User;
using Infrastructure.Data.Config.CompanyConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<SystemEmployee> SystemEmployees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomMaintenance> RoomMaintenances { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<BlackList> BlackLists { get; set; }
        public DbSet<InvoiceTax> InvoiceTaxes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(CompanyConfig).Assembly);
        }
    }
}
