using Repository.Seguridad.Options;
using Entity.Entitys;
using ApplicationService.Common;
using ApplicationService.Seguridad.Maps;
using System.Collections.Generic;

namespace ApplicationService.IServices
{
    public  interface IUserService
    {
        bool Login(string username, string pass);
        Response InsertUser(User user);
        Response UpdateUser(User user);
        Response DeleteUser(int userId);
        User GetUserbyId(int userId);
        User GetUserbyUsername(string username);
        Response ChangePassword(int userId, string pass);
        List<UserGrid> FindAllUsers(UserSearchOptions options = null);
    }
}
