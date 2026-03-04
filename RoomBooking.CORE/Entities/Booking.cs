using RoomBooking.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.CORE.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public Guid UserId { get; set; }
        public BookingStatus Status { get; set; }
        public decimal TotalPrice { get ; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } =string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateTime ReservationDate { get; set; } 
    }
}
