using RoomBooking.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.CORE.Interfaces.Repositories
{
    public interface IBookingRepository
    {

        Task<Booking> GetByIdAsync(Guid id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> GetByRoomIdAsync(Guid roomId);
        Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId);
        Task<bool> IsRoomAvailableAsync(Guid roomId, DateOnly start, DateOnly end);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(Guid id);
    }
}
