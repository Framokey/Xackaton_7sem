using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Bookings>> GetRoomsByFilter(DateTime date, int capacity, int workspace)
        {
            var freeRooms = await _bookingRepository.GetRoomsByFilter(date, capacity, workspace);
            return freeRooms;
        }
        public async Task CreateBooking(BookingDto bookingDto)
        {
            var newBooking = new Bookings { 
                UserId = bookingDto.UserId,
                RoomId = bookingDto.RoomId,
                WorkspaceId = bookingDto.WorkspaceId,
                Description = bookingDto.Description,
                BookingTime = DateTime.UtcNow,
                StartTime = bookingDto.StartTime,
                EndTime = bookingDto.EndTime
            };

           await _bookingRepository.CreateBooking(newBooking);
        }
    }
}
