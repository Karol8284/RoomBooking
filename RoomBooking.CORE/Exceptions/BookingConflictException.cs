using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.CORE.Exceptions
{
    public class BookingConflictException : Exception
    {
        public BookingConflictException(Guid roomId) 
            : base($"Room {roomId} is already booked for this period.") { }


    }
}
