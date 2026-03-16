using Microsoft.AspNetCore.Mvc;
using RoomBooking.CORE.Interfaces.Services;
using RoomBooking.Shared.DTOs.Bookings;

namespace RoomBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingRepository)
        {
            _bookingService = bookingRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Book(CreateBookingRequest request)
        {
            var result = await _bookingService.BookAsync(
         
                request.RoomId, request.UserId,request.Start,request.End);
            if(!result.IsSuccess)       
                return BadRequest(result.Error);
            return Ok(result.Value);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var result = await _bookingService.CancelAsync(id);
            if(!result.IsSuccess)
                return BadRequest(result.Error);
            return NoContent();
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBookings(Guid userId)
        {
            var result = await _bookingService.GetUserBookingsAsync(userId);
            return Ok(result.Value);
        }
    }
}