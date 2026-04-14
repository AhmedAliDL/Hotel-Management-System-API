using Domain.Entities.Contract;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.SystemEmployeeEntity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.InvoiceItemsEntity
{
    public class InvoiceItems : ISoftDeletable
    {
        public Guid Id { get; set; }
        [MaxLength(255, ErrorMessage = "Item`s name must be less than 256")]
        [MinLength(50, ErrorMessage = "Item`s name must be greater than 49")]
        public required string ItemName { get; set; }
        public int Quantity { get; set; }
        public double PriceOfItem { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid InvoiceId { get; set; }
        public Guid CreatedBy { get; set; }

        public Invoice Invoice { get; set; }
        public SystemEmployee CreatedByEmployee { get; set; }


    }
}
