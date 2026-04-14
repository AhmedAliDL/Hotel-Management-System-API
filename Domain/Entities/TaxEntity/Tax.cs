using Domain.Entities.BranchEntity;
using Domain.Entities.Contract;
using Domain.Entities.InvoiceTaxEntity;
using Domain.Enums;

namespace Domain.Entities.TaxConfigEntity
{
    public class Tax : ISoftDeletable
    {
        public Guid Id { get; set; }
        public TaxType TaxName { get; set; }
        public double TaxRate { get; set; }
        public Currency CurrencyCode { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid BranchId { get; set; }

        public Branch Branch { get; set; }
        public ICollection<InvoiceTax>? InvoiceTaxes { get; set; }


    }
}
