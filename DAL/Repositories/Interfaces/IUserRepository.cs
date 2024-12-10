using Domain.Models;

namespace DAL.Interfaces.User
{
    ///<summary>
    ///Сотрудник рабочей смены
    ///</summary>
    public interface IUserRepository
    {
        ///<summary>
        ///Добавление нового сотрудника
        ///</summary>
        Task AddAsync(UserDto userDto);

        ///<summary>
        ///Получение сотрудника по имени
        ///</summary>
        Task<Models.Users> GetUserByEmailAsync(string email);
    }
}
