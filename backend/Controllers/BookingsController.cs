using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("Filter")]
        public async Task<ActionResult<IEnumerable<Bookings>>> BaseFilter(DateTime date, int capacity, int workspace)
        {
            var freeRooms = await _bookingService.GetRoomsByFilter(date, capacity, workspace);
            return Ok(freeRooms);
        }
    }
}
