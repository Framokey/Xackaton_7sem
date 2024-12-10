namespace DAL.Models
{
    public class Photos
    {
        public int PhotoId { get; set; } // Первичный ключ
        public int RoomId { get; set; } // Внешний ключ
        public string UrlFile { get; set; }
    }
}