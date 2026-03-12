using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.CORE.Exceptions
{
    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException(Guid id) 
            : base($"Room with id {id} was not found.") { } 
    }
}
