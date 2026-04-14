using Domain.Entities.BlackListEntity;
using Domain.Entities.BookingEntity;
using Domain.Entities.BookingServiceEntity;
using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Entities.GuestEntity;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.InvoiceItemsEntity;
using Domain.Entities.PaymentEntity;
using Domain.Entities.RoomMaintenanceEntity;
using Domain.Entities.User;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities.SystemEmployeeEntity
{
    public class SystemEmployee : ISoftDeletable
    {
        public Guid Id { get; set; }
        [MaxLength(100, ErrorMessage = "Employee`s name must be less than 101")]
        [MinLength(10, ErrorMessage = "Employee`s name must be greater than 9")]
        public required string EmployeeName { get; set; }
        public Gender EmployeeGender { get; set; }
        public Guid ConfirmedCompanyIdentifier { get; set; }
        public Guid ConfirmedBranchIdentifier { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }


        public Company Company { get; set; }
        public Branch Branch { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Guest> Guests { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<BlackList> BlackLists { get; set; }
        public ICollection<InvoiceItems> InvoiceItems { get; set; }
        public ICollection<RoomMaintenance> RoomMaintenances { get; set; }
        public ICollection<BookingService> BookingServices { get; set; }
    }
}
