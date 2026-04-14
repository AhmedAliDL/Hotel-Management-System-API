using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Entities.GuestEntity;
using Domain.Entities.SystemEmployeeEntity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.BlackListEntity
{
    public class BlackList : ISoftDeletable
    {
        public Guid Id { get; set; }
        [MaxLength(255, ErrorMessage = "Reason must be less than 256")]
        [MinLength(50, ErrorMessage = "Reason must be greater than 49")]
        public required string Reason { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid CompanyId { get; set; }
        public Guid GuestId { get; set; }
        public Guid BranchId { get; set; }
        public Guid CreatedBy { get; set; }

        public Company Company { get; set; }
        public Guest Guest { get; set; }
        public Branch Branch { get; set; }
        public SystemEmployee CreatedByEmployee { get; set; }

    }
}
