using Domain.Entities.BookingEntity;
using Domain.Entities.Contract;
using Domain.Entities.ServiceEntity;
using Domain.Entities.SystemEmployeeEntity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.BookingServiceEntity
{
    public class BookingService : ISoftDeletable
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        [MaxLength(255, ErrorMessage = "Notes must be less than 256")]
        [MinLength(50, ErrorMessage = "Notes must be greater than 49")]
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid CreatedBy { get; set; }
        public Guid BookingId { get; set; }
        public Guid ServiceId { get; set; }

        public Booking Booking { get; set; }
        public Service Service { get; set; }
        public SystemEmployee CreatedByEmployee { get; set; }
    }
}
