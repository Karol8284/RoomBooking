using RoomBooking.CORE.Entities;
using RoomBooking.CORE.Enums;
using RoomBooking.CORE.Interfaces.Repositories;
using RoomBooking.CORE.Interfaces.Services;
using RoomBooking.CORE.Responses;
using RoomBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooking.Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        public async Task<Result<Booking>> BookAsync(Guid roomId, Guid userId, DateOnly start, DateOnly end)
        {
            var room = await _roomRepository.GetByIdAsync(roomId);

            var isAvailable = await _bookingRepository.IsRoomAvailableAsync(roomId, start, end);

            if (!isAvailable)
                return Result<Booking>.Failure("Room isn't available for selected data.");

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                RoomId = roomId,
                UserId = userId,
                StartDate = start,
                EndDate = end,
                Status = BookingStatus.Pending,
                TotalPrice = room.Price * (end.DayNumber - start.DayNumber),
                ReservationDate = DateTime.UtcNow
            };

            await _bookingRepository.AddAsync(booking);
            return Result<Booking>.Success(booking);
        }

        public async Task<Result<bool>> CancelAsync(Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            booking.Status = BookingStatus.Cancelled;
            await _bookingRepository.UpdateAsync(booking);
            return Result<bool>.Success(true);
        }

        public async Task<Result<IEnumerable<Booking>>> GetUserBookingsAsync(Guid userId)
        {
            var bookings = await _bookingRepository.GetByUserIdAsync(userId);
            return Result<IEnumerable<Booking>>.Success(bookings);
        }

        public async Task<Result<bool>> IsRoomAvailableAsync(Guid roomId, DateOnly start, DateOnly end)
        {
            var isAvailable = await _bookingRepository.IsRoomAvailableAsync(roomId, start, end);
            return Result<bool>.Success(isAvailable);
        }
    }
}
