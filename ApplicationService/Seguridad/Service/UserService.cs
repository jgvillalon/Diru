using Repository.Common;
using Repository.IRepository;
using Repository.Seguridad.Options;
using Entity.Entitys;
using ApplicationService.Common;
using ApplicationService.IServices;
using ApplicationService.Seguridad.Maps;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationService.Service
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
           
            _userRepository = userRepository;
        }

        public Response DeleteUser(int userId)
        {
            var user = _userRepository.GetUserbyId(userId);

            if (user != null) { 
            var status = _userRepository.DeleteUser(user);
            return new Response
            {
                Status = status
            };

            }
            return new Response
            {
                Status = StatusResponse.NotFound
            };
        }

        public List<UserGrid> FindAllUsers(UserSearchOptions options = null)
        {
           var userList = _userRepository.FindAllUsers(options);
            return Mapping.Mapper.Map<List<UserGrid>>(userList);

        }

        public User GetUserbyId(int userId)
        {
            return _userRepository.GetUserbyId(userId);
        }
        public User GetUserbyUsername(string username)
        {
            return _userRepository.GetUserbyUsername(username);
        }

        public Response InsertUser(User user)
        {
            user.Password = Sha256encrypt(user.Password);
            var status = _userRepository.InsertUser(user);
            return new Response
            {
                Status = status
            };
        }

      public Response UpdateUser(User user)
        {
            var status = _userRepository.UpdateUser(user);
            return new Response
            {
                Status = status
            };
        }


        public bool Login(string username, string pass)
        {
            var user = _userRepository.GetUserbyUserName(username);
            if (user != null && user.Password.Equals(Sha256encrypt(pass)))
                return true;
            return false;


        }

        public Response ChangePassword(int userId, string pass)
        {
            if (!string.IsNullOrEmpty(pass))
            {
                var user = _userRepository.GetUserbyId(userId);
                user.Password = Sha256encrypt(pass);

                var status = _userRepository.UpdateUser(user);
                return new Response
                {
                    Status = status
                };
            }
            return new Response
            {
                Status = StatusResponse.Error
            };


        }

        /* Encriptar pass*/
        public  string Sha256encrypt(string pass)
        {
            UTF8Encoding encoder = new UTF8Encoding();
           SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(pass));
            return Convert.ToBase64String(hashedDataBytes);
        }

    }
}
