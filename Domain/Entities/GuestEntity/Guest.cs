using Domain.Entities.BlackListEntity;
using Domain.Entities.BookingEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.GuestEntity
{
    public class Guest : ISoftDeletable
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        [MinLength(10)]
        public required string GuestName { get; set; }
        [MaxLength(24, ErrorMessage = "Guest`s national id must be less than 25")]
        [MinLength(10, ErrorMessage = "Guest`s national id must be greaterthan 11")]
        public required string GuestNationalId { get; set; }
        public NationalIdType GuestNationalIdType { get; set; }
        public NationalityType Nationality { get; set; }
        public CountryCodeForPhoneNumber GuestCountryCodeForPhoneNumber { get; set; }
        [MaxLength(15, ErrorMessage = "Phone number must be less than 16")]
        [MinLength(7, ErrorMessage = "Phone number must be greaterthan 6")]
        public required string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public Gender GuestGender { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid email format for example:ex@gmail.com")]
        public required string Email { get; set; }
        public PreferredLanguage GeustPrefereedLanguage { get; set; }

        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid CompanyId { get; set; }
        public Guid CreatedBy { get; set; }

        public Company Company { get; set; }
        public SystemEmployee CreatedByEmployee { get; set; }
        public BlackList? BlackList { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

    }
}
