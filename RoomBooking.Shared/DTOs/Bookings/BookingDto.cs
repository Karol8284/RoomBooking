using RoomBooking.CORE.Enums;
namespace RoomBooking.Shared.DTOs.Bookings
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public decimal Price { get; set; }
        public BookingStatus Status { get; set; }
    }
}
