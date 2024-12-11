using DAL.Models;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Bookings>> GetRoomsByFilter(DateTime date, int capacity, int workspace);
        Task<IEnumerable<Bookings>> GetUserHistory(int userId);
        Task CreateBooking(Bookings bookings);
    }
}
