using RoomBooking.CORE.Entities;
using RoomBooking.CORE.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.CORE.Interfaces.Services
{
    public interface IBookingService
    {
        Task<Result<Booking>> BookAsync(Guid roomId, Guid userId, DateOnly start, DateOnly end);
        Task<Result<bool>> CancelAsync(Guid bookingId);
        Task<Result<IEnumerable<Booking>>> GetUserBookingsAsync(Guid userId);
        Task<Result<bool>> IsRoomAvailableAsync(Guid roomId, DateOnly start, DateOnly end);
    }
}
