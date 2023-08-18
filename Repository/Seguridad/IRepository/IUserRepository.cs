using Repository.Common;
using Repository.Seguridad.Options;
using Entity.Entitys;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface IUserRepository
    {
        List<User> FindAllUsers(UserSearchOptions options);
        StatusResponse InsertUser(User user);
        StatusResponse UpdateUser(User user);
        StatusResponse DeleteUser(User user);
        User GetUserbyId(int userId);
        User GetUserbyUsername(string username);
        User GetUserbyUserName(string username);
    }
}
