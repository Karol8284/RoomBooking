using RoomBooking.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.CORE.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public RoomType Type {  get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
