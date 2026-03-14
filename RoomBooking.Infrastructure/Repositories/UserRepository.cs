using Microsoft.EntityFrameworkCore;
using RoomBooking.CORE.Entities;
using RoomBooking.CORE.Interfaces.Repositories;
using RoomBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ??
                throw new KeyNotFoundException($"User with email '{email}' not found.");
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id) ??
                throw new KeyNotFoundException($"User with id {id} not found.");
        }
        public async Task UpdateAsync(User user)
        {
            await _context.Users.Where(u => u.Id == user.Id)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.FirstName, user.FirstName)
                    .SetProperty(p => p.LastName, user.LastName)
                    .SetProperty(p => p.Email, user.Email)
                    .SetProperty(p => p.PhoneNumber, user.PhoneNumber)
                    .SetProperty(p => p.Address, user.Address));
        }
    }
}
