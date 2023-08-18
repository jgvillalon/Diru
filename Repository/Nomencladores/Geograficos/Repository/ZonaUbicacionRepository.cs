using Entity.Entitys.Nomencladores.Geograficos;
using NHibernate;
using Repository.Common;
using Repository.Nomencladores.Geograficos.IRepository;
using Repository.Nomencladores.Geograficos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Geograficos.Repository
{
   public class ZonaUbicacionRepository : TRepository, IZonaUbicacionRepository
    {
        private readonly ISession _session;
        public ZonaUbicacionRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteZonaUbicacion(ZonaUbicacion zonaUbicacion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(zonaUbicacion);
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

        public List<ZonaUbicacion> FindAllZonaUbicacions(ZonaUbicacionSearchOptions options = null)
        {
            var query = _session.Query<ZonaUbicacion>();
            if (options != null)
            {

                //if (!string.IsNullOrWhiteSpace(options.Nombre))
                //    query = query.Where(u => u.Nombre.Contains(options.Nombre));

                //if (!string.IsNullOrWhiteSpace(options.ZonaUbicacionname))
                //    query = query.Where(u => u.ZonaUbicacionname.Contains(options.ZonaUbicacionname));

                //if (options.Active.HasValue)
                //    query = query.Where(u => u.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public ZonaUbicacion GetZonaUbicacionbyId(int zonaUbicacionId)
        {
            return _session.Query<ZonaUbicacion>().FirstOrDefault(u => u.Id.Equals(zonaUbicacionId));
        }



        public StatusResponse InsertZonaUbicacion(ZonaUbicacion zonaUbicacion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(zonaUbicacion);
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

        public StatusResponse UpdateZonaUbicacion(ZonaUbicacion zonaUbicacion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(zonaUbicacion);
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

