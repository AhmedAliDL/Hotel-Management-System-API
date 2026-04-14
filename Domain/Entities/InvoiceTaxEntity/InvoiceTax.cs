using Domain.Entities.Contract;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.TaxConfigEntity;

namespace Domain.Entities.InvoiceTaxEntity
{
    public class InvoiceTax : ISoftDeletable
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid InvoiceId { get; set; }
        public Guid TaxConfigId { get; set; }

        public Invoice Invoice { get; set; }
        public Tax Tax { get; set; }
    }
}
