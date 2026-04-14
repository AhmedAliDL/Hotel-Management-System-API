using Domain.Entities.AmenityEntity;
using Domain.Entities.BlackListEntity;
using Domain.Entities.BranchEntity;
using Domain.Entities.Contract;
using Domain.Entities.GuestEntity;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.PaymentEntity;
using Domain.Entities.RoomTypeEntity;
using Domain.Entities.ServiceEntity;
using Domain.Entities.SubscriptionEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Entities.User;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.CompanyEntity
{
    public class Company : ISoftDeletable
    {
        public Guid Id { get; set; }
        [MaxLength(255, ErrorMessage = "Company`s name must be less than 256")]
        [MinLength(50, ErrorMessage = "Company`s name must be greater than 49")]
        public required string CompanyName { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        [MaxLength(255, ErrorMessage = "address must be less than 256")]
        [MinLength(50, ErrorMessage = "address must be greater than 49")]
        public required string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Amenity> Amenities { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public ICollection<Guest> Guests { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<SystemEmployee> SystemEmployees { get; set; }
        public ICollection<BlackList> BlackLists { get; set; }
    }
}
