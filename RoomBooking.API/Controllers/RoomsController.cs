using Microsoft.AspNetCore.Mvc;
using RoomBooking.CORE.Entities;
using RoomBooking.CORE.Interfaces.Repositories;
using RoomBooking.Shared.DTOs.Rooms;
namespace RoomBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return Ok(rooms);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if(room == null) return NotFound();
            return Ok(room);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomRequest request)
        {
            var room = new Room
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Location = request.Location,
                Type = request.Type,
                OwnerId = request.OwnerId,
            };

            await _roomRepository.AddAsync(room);
            return CreatedAtAction(nameof(GetById), new {id = room.Id}, room);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateRoomRequest request)
        {
            var updateRoom = new Room
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Location = request.Location,
                Type= request.Type,
                OwnerId= request.OwnerId,
            };
            await _roomRepository.UpdateAsync(updateRoom);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _roomRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
