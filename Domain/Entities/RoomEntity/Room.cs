using Domain.Entities.BookingRoomEntity;
using Domain.Entities.BranchEntity;
using Domain.Entities.Contract;
using Domain.Entities.RoomAmenityEntity;
using Domain.Entities.RoomMaintenanceEntity;
using Domain.Entities.RoomTypeEntity;
using Domain.Enums;

namespace Domain.Entities.RoomEntity
{
    public class Room : ISoftDeletable
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int MaximumOccupancy { get; set; }
        public RoomStatus Status { get; set; }
        public double RoomPrice { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid RoomTypeId { get; set; }
        public Guid BranchId { get; set; }

        public RoomType RoomType { get; set; }
        public Branch Branch { get; set; }
        public ICollection<BookingRoom> BookingRooms { get; set; }
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
        public ICollection<RoomMaintenance> RoomMaintenances { get; set; }
    }
}
