using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Entities.RoomAmenityEntity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.AmenityEntity
{
    public class Amenity : ISoftDeletable
    {
        public Guid Id { get; set; }
        public AmenityType Type { get; set; }
        [MaxLength(255, ErrorMessage = "Description must be less than 256")]
        [MinLength(50, ErrorMessage = "Description must be greater than 49")]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid CompanyId { get; set; }
        public Guid? BranchId { get; set; }

        public Company Company { get; set; }
        public Branch? Branch { get; set; }
        public ICollection<RoomAmenity> RoomAmenities { get; set; }

    }
}
