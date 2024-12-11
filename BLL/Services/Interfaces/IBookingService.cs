using DAL.Models;
using Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Bookings>> GetRoomsByFilter(DateTime date, int capacity, int workspace);
        Task<IEnumerable<Bookings>> GetHistoryByUser(int userId);
        Task CreateBooking(BookingDto bookingDto);
    }
}
