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
   public class EntidadRepository : TRepository, IEntidadRepository
    {
        private readonly ISession _session;
        public EntidadRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteEntidad(Entidad entidad)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(entidad);
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

        public List<Entidad> FindAllEntidades(EntidadSearchOptions options = null)
        {
            var query = _session.Query<Entidad>();
            if (options != null)
            {
                if (options.Active.HasValue)
                    query = query.Where(e => e.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public Entidad GetEntidadbyId(int entidadId)
        {
            return _session.Query<Entidad>().FirstOrDefault(u => u.Id.Equals(entidadId));
        }

     

        public StatusResponse InsertEntidad(Entidad entidad)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(entidad);
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

        public StatusResponse UpdateEntidad(Entidad entidad)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(entidad);
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
