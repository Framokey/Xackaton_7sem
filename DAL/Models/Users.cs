namespace DAL.Models
{
    public class Users
    {
        public int UserId { get; set; } // Первичный ключ
        public string TgId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; } // Внешний ключ
    }
}