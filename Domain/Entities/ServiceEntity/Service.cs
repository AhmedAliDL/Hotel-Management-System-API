using Domain.Entities.BookingServiceEntity;
using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Enums;

namespace Domain.Entities.ServiceEntity
{
    public class Service : ISoftDeletable
    {
        public Guid Id { get; set; }
        public ServiceType Type { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid CompanyId { get; set; }
        public Guid? BranchId { get; set; }

        public Company Company { get; set; }
        public Branch? Branch { get; set; }
        public ICollection<BookingService> BookingServices { get; set; }
    }
}
