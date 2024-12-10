using DAL.Models;
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
    }
}
