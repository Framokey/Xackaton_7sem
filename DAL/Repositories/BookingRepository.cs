using DAL.Models;
using DAL.Repositories.Interfaces;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly WorkspacesDbContext _context;

        public BookingRepository(WorkspacesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bookings>> GetRoomsByFilter(DateTime date, int capacity, int workspace)
        {
            var curDate = date.Date;

            var rooms = _context.Rooms.AsQueryable()
                .Where(x => x.Capacity >= capacity)
                .Select(x => x.RoomId);

            var bookings = _context.Bookings.AsQueryable()
                .Where(x => x.WorkspaceId == workspace)
                .Where(x => x.StartTime.Date == curDate || x.EndTime.Date == curDate);

            var result = await bookings.Where(x => rooms.Contains(x.RoomId)).ToListAsync();

            return result;
        }

        public async Task CreateBooking(Bookings bookings)
        {
            var test = bookings.ToString();
            await _context.Bookings.AddAsync(bookings);
            await _context.SaveChangesAsync();
        }

    }
}
