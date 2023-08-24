using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
using NHibernate;
using Repository.Common;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using Repository.Nomencladores.Otros.IRepository;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.Repository
{
    public class RedRepository : TRepository, IRedRepository
    {
        private readonly ISession _session;
        public RedRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteRed(Red Red)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(Red);
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

        public List<Red> FindAllReds(RedSearchOptions options = null)
        {
            var query = _session.Query<Red>();
            if (options != null)
            {

              if (options.Nombre != null)
                    query = query.Where(o => o.Nombre.Equals(options.Nombre));

            }
            return query.ToList();
        }

        public Red GetRedbyId(int RedId)
        {
            return _session.Query<Red>().FirstOrDefault(u => u.Id.Equals(RedId));
        }



        public StatusResponse InsertRed(Red Red)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(Red);
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

        public StatusResponse UpdateRed(Red Red)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(Red);
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
