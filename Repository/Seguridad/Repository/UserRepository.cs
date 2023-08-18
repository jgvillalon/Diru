using Repository.Common;
using Repository.IRepository;
using Repository.Seguridad.Options;
using Entity.Entitys;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
   public class UserRepository : TRepository, IUserRepository
    {
        private readonly ISession _session;
        public UserRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteUser(User user)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(user);
                    transaction.Commit();

                }
                return StatusResponse.OK;
            }
            catch (Exception e)
            {
                _session.Clear();
                var msg = e.InnerException.Message;
                if (msg.Contains("23503:"))
                    return StatusResponse.InUse;
                return StatusResponse.Error;
            }
        }

        public List<User> FindAllUsers(UserSearchOptions options = null)
        {
           var query = _session.Query<User>();
            if (options != null) {

                if (!string.IsNullOrWhiteSpace(options.Nombre))
                    query = query.Where(u => u.Nombre.Contains(options.Nombre));

                if (!string.IsNullOrWhiteSpace(options.Username))
                    query = query.Where(u => u.Username.Contains(options.Username));

                if (options.Active.HasValue)
                    query = query.Where(u => u.Active == options.Active.Value);

            }
            query = query.Where(u => u.UserRole.Role != Role.SuperAdministrador);
            return query.ToList();
        }

        public User GetUserbyId(int userId)
        {
            return _session.Query<User>().FirstOrDefault(u => u.Id.Equals(userId));
        }

        public User GetUserbyUsername(string username)
        {
            return _session.Query<User>().FirstOrDefault(u => u.Username.Equals(username));
        }

        public StatusResponse InsertUser(User user)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(user);
                    transaction.Commit();

                }
                return StatusResponse.OK;
            }
            catch (Exception e)
            {
                _session.Clear();
                var msg = e.InnerException.Message;
                if (msg.Contains("23505:"))
                    return StatusResponse.Exist;

                return StatusResponse.Error;

            }
        }

        public StatusResponse UpdateUser(User user)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(user);
                    transaction.Commit();

                }
                return StatusResponse.OK;
            }
            catch (Exception)
            {
                _session.Clear();
                return StatusResponse.Error;
            }
        }

        public User GetUserbyUserName(string username)
        {
            return _session.Query<User>().FirstOrDefault(u => u.Username.Equals(username));
        }

    }
}
