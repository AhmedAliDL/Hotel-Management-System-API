using Domain.Entities.BookingRoomEntity;
using Domain.Entities.BookingServiceEntity;
using Domain.Entities.BranchEntity;
using Domain.Entities.Contract;
using Domain.Entities.GuestEntity;
using Domain.Entities.InvoiceEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Enums;

namespace Domain.Entities.BookingEntity
{
    public class Booking : ISoftDeletable
    {
        public Guid Id { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public BookingStatus Status { get; set; }
        public int NumberOfGuests => NumberOfAdults + NumberOfChildren;
        public int NumberOfRooms { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Guid GuestId { get; set; }
        public Guid BranchId { get; set; }
        public Guid CreatedBy { get; set; }


        public Guest Guest { get; set; }
        public Branch Branch { get; set; }
        public SystemEmployee CreatedByEmployee { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<BookingRoom> BookingRooms { get; set; }
        public ICollection<BookingService> BookingServices { get; set; }
    }
}
