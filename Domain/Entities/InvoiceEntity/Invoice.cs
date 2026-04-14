using Domain.Entities.BookingEntity;
using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Entities.GuestEntity;
using Domain.Entities.InvoiceItemsEntity;
using Domain.Entities.InvoiceTaxEntity;
using Domain.Entities.PaymentEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.InvoiceEntity
{
    public class Invoice : ISoftDeletable
    {
        public Guid Id { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountInvoiceType { get; set; }
        public double SubTotal { get; set; }
        public double TotalPrice { get; set; }
        public Currency CurrencyCode { get; set; }
        public InvoiceStatus Status { get; set; }
        [MaxLength(255, ErrorMessage = "Voided reason must be less than 256")]
        [MinLength(50, ErrorMessage = "voided reason must be greater than 49")]
        public string? VoidedReason { get; set; }
        [MaxLength(255, ErrorMessage = "Issued reason must be less than 256")]
        [MinLength(50, ErrorMessage = "Issued reason must be greater than 49")]
        public string? IssuedReason { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid BookingId { get; set; }
        public Guid GuestId { get; set; }
        public Guid BranchId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CreatedBy { get; set; }

        public Booking Booking { get; set; }
        public Guest Guest { get; set; }
        public Branch Branch { get; set; }
        public Company Company { get; set; }
        public SystemEmployee CreatedByEmployee { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<InvoiceTax>? InvoiceTaxes { get; set; }
        public ICollection<InvoiceItems> InvoiceItems { get; set; }
    }
}
