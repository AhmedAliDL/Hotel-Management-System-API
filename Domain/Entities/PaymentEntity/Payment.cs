using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Enums;

namespace Domain.Entities.PaymentEntity
{
    public class Payment : ISoftDeletable
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public Currency CurrencyCode { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid InvoiceId { get; set; }
        public Guid BranchId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CreatedBy { get; set; }

        public Invoice Invoice { get; set; }
        public Branch Branch { get; set; }
        public Company Company { get; set; }
        public SystemEmployee CreatedByEmployee { get; set; }
    }
}
