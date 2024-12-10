using Domain.Models;

namespace DAL.Interfaces.User
{
    ///<summary>
    ///Сотрудник рабочей смены
    ///</summary>
    public interface IUserService
    {
        ///<summary>
        ///Регистрация сотрудника
        ///</summary>
        Task Register(string name, string password);

        ///<summary>
        ///Аутентификация сотрудника
        ///</summary>
        Task<UserDto> Login(string email, string password);

        ///<summary>
        ///Генерация хэша пароля
        ///</summary>
        string Generate(string password);

        ///<summary>
        ///Верификация хэша пароля
        ///</summary>
        bool Verify(string password, string hashedPassword);
    }
}