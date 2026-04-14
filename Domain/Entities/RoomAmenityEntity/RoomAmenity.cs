using Domain.Entities.AmenityEntity;
using Domain.Entities.Contract;
using Domain.Entities.RoomEntity;

namespace Domain.Entities.RoomAmenityEntity
{
    public class RoomAmenity : ISoftDeletable
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }
        public Guid AmenityId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
    }
}
