using RoomBooking.CORE.Entities;
namespace RoomBooking.CORE.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(Guid id);
        Task<IEnumerable<Room>> GetAllAsync();
        Task AddAsync(Room room);
        Task UpdateAsync(Room room);
        Task DeleteAsync(Guid id);
    }
}
