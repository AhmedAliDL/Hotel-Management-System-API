using Domain.Entities.Contract;
using Domain.Entities.RoomEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.RoomMaintenanceEntity
{
    public class RoomMaintenance : ISoftDeletable
    {
        public Guid Id { get; set; }
        [MaxLength(255, ErrorMessage = "Reason must be less than 256")]
        [MinLength(50, ErrorMessage = "Reason must be greater than 49")]
        public required string Reason { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        [MaxLength(100, ErrorMessage = "Employee`s name must be less than 101")]
        [MinLength(10, ErrorMessage = "Employee`s name must be greater than 9")]
        public required string AssignedTo { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid RoomId { get; set; }
        public Guid CreatedById { get; set; }

        public Room Room { get; set; }
        public SystemEmployee CreatedByEmployee { get; set; }
    }
}
