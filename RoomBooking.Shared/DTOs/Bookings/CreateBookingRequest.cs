namespace RoomBooking.Shared.DTOs.Bookings
{
    public class CreateBookingRequest
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
    }
}