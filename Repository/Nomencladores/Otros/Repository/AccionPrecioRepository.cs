using Entity.Entitys.Nomencladores.Otros;
using NHibernate;
using Repository.Common;
using Repository.Nomencladores.Otros.IRepository;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.Repository
{
    public class AccionPrecioRepository : TRepository, IAccionPrecioRepository
    {
        private readonly ISession _session;
        public AccionPrecioRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteAccionPrecio(AccionPrecio accionPrecio)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(accionPrecio);
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

        public List<AccionPrecio> FindAllAccionPrecios(AccionPrecioSearchOptions options = null)
        {
            var query = _session.Query<AccionPrecio>();
            if (options != null)
            {

                //if (options.Active.HasValue)
                //    query = query.Where(o => o.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public AccionPrecio GetAccionPreciobyId(int accionPrecioId)
        {
            return _session.Query<AccionPrecio>().FirstOrDefault(u => u.Id.Equals(accionPrecioId));
        }



        public StatusResponse InsertAccionPrecio(AccionPrecio accionPrecio)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(accionPrecio);
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

        public StatusResponse UpdateAccionPrecio(AccionPrecio accionPrecio)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(accionPrecio);
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
