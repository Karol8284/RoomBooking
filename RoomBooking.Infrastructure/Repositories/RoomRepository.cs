using Microsoft.EntityFrameworkCore;
using RoomBooking.CORE.Entities;
using RoomBooking.CORE.Interfaces.Repositories;
using RoomBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Rooms.Where(r => r.Id == id).ExecuteDeleteAsync();
        }
        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> GetByIdAsync(Guid id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id) ??
                throw new KeyNotFoundException($"Room with id {id} not found.");
        }

        public async Task UpdateAsync(Room room)
        {
            await _context.Rooms.Where(r => r.Id == room.Id).ExecuteUpdateAsync(r =>
            r.SetProperty(r => r.Name, room.Name)
            .SetProperty(r => r.Description, room.Description)
            .SetProperty(r => r.Price, room.Price)
            .SetProperty(r => r.Location, room.Location)
            .SetProperty(r => r.Type, room.Type)
            );
        }

    }
}
