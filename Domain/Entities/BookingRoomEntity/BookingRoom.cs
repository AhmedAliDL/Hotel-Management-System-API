using Domain.Entities.BookingEntity;
using Domain.Entities.Contract;
using Domain.Entities.RoomEntity;

namespace Domain.Entities.BookingRoomEntity
{
    public class BookingRoom : ISoftDeletable
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid BookingId { get; set; }
        public Guid RoomId { get; set; }


        public Booking Booking { get; set; }
        public Room Room { get; set; }
    }
}
