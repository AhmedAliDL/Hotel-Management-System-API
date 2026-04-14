using Domain.Entities.AmenityEntity;
using Domain.Entities.BlackListEntity;
using Domain.Entities.BookingEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Entities.GuestEntity;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.PaymentEntity;
using Domain.Entities.RoomEntity;
using Domain.Entities.RoomTypeEntity;
using Domain.Entities.ServiceEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Entities.TaxConfigEntity;
using Domain.Entities.User;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.BranchEntity
{
    public class Branch : ISoftDeletable
    {
        public Guid Id { get; set; }
        [MaxLength(255, ErrorMessage = "Branch`s name must be less than 256")]
        [MinLength(50, ErrorMessage = "Branch`s name must be greater than 49")]
        public required string BranchName { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        [MaxLength(255, ErrorMessage = "Branch`s address must be less than 256")]
        [MinLength(50, ErrorMessage = "Branch`s address must be greater than 49")]
        public required string Address { get; set; }
        public bool IsActive { get; set; }
        public Guid ConfirmedCompanyIdentifier { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }

        public ApplicationUser User { get; set; }
        public Company Company { get; set; }
        public ICollection<Amenity>? Amenities { get; set; }
        public ICollection<BlackList> BlackLists { get; set; }
        public ICollection<Guest> Guests { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<RoomType>? RoomTypes { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<SystemEmployee> SystemEmployees { get; set; }
        public ICollection<Tax> Taxes { get; set; }

    }
}
