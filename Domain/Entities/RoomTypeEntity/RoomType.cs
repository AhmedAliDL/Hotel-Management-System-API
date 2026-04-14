using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.Contract;
using Domain.Entities.RoomEntity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.RoomTypeEntity
{
    public class RoomType : ISoftDeletable
    {
        public Guid Id { get; set; }
        public RoomTypeName TypeName { get; set; }
        [MaxLength(255, ErrorMessage = "Description must be less than 256")]
        [MinLength(50, ErrorMessage = "Description must be greater than 49")]
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid CompanyId { get; set; }
        public Guid? BranchId { get; set; }

        public Company Company { get; set; }
        public Branch? Branch { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
