namespace DAL.Models
{
    public class Rooms
    {
        public int RoomId { get; set; }
        public int WorkspaceId { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public bool HasScreen { get; set; }
    }
}