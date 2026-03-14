using Microsoft.EntityFrameworkCore;
using RoomBooking.CORE.Entities;
using RoomBooking.CORE.Interfaces.Repositories;
using RoomBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;
        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Bookings.Where(b => b.Id == id).ExecuteDeleteAsync();
        }
        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }
        public async Task<Booking> GetByIdAsync(Guid id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(r => r.Id == id) ??
                throw new KeyNotFoundException($"Booking with id {id} not found.");
        }
        public async Task<IEnumerable<Booking>> GetByRoomIdAsync(Guid roomId)
        {
            return await _context.Bookings.Where(b => b.RoomId == roomId).ToListAsync();
        }
        public async Task<IEnumerable<Booking>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Bookings.Where(b => b.UserId == userId).ToListAsync();
        }
        public async Task<bool> IsRoomAvailableAsync(Guid roomId, DateOnly start, DateOnly end)
        {
            return !await _context.Bookings.AnyAsync(b => b.RoomId == roomId &&
                ((b.StartDate <= start && b.EndDate >= start) ||
                 (b.StartDate <= end && b.EndDate >= end) ||
                 (b.StartDate >= start && b.EndDate <= end)));
        }

        public async Task UpdateAsync(Booking booking)
        {
            await _context.Bookings.Where(b => b.Id == booking.Id).ExecuteUpdateAsync(b =>
                b.SetProperty(x => x.RoomId, booking.RoomId)
                 .SetProperty(x => x.UserId, booking.UserId)
                 .SetProperty(x => x.Status, booking.Status)
                 .SetProperty(x => x.TotalPrice, booking.TotalPrice)
                 .SetProperty(x => x.Name, booking.Name)
                 .SetProperty(x => x.Description, booking.Description)
                 .SetProperty(x => x.StartDate, booking.StartDate)
                 .SetProperty(x => x.EndDate, booking.EndDate));
        }
    }
}
