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
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Branch> Branches { get; set; }
        DbSet<Guest> Guests { get; set; }
        DbSet<SystemEmployee> SystemEmployees { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<InvoiceItems> InvoiceItems { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<Amenity> Amenities { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<RoomAmenity> RoomAmenities { get; set; }
        DbSet<RoomType> RoomTypes { get; set; }
        DbSet<RoomMaintenance> RoomMaintenances { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<BookingService> BookingServices { get; set; }
        DbSet<BookingRoom> BookingRooms { get; set; }
        DbSet<Tax> Taxes { get; set; }
        DbSet<BlackList> BlackLists { get; set; }
        DbSet<InvoiceTax> InvoiceTaxes { get; set; }
    }

}