namespace DAL.Models
{
    public class Bookings
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int WorkspaceId { get; set; }
        public string Description { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}