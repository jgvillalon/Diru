using Entity.Entitys.Nomencladores.Generales;
using NHibernate;
using Repository.Common;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Generales.Repository
{
    public class LocalRepository : TRepository, ILocalRepository
    {
        private readonly ISession _session;
        public LocalRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteLocal(Local local)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(local);
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

        public List<Local> FindAllLocals(LocalSearchOptions options = null)
        {
            var query = _session.Query<Local>();
            if (options != null)
            {

                //if (options.Active.HasValue)
                //    query = query.Where(o => o.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public Local GetLocalbyId(int localId)
        {
            return _session.Query<Local>().FirstOrDefault(u => u.Id.Equals(localId));
        }



        public StatusResponse InsertLocal(Local local)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(local);
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

        public StatusResponse UpdateLocal(Local local)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(local);
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



    }
}
