using Entity.Entitys.Proyectos;
using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using NHibernate;
using Repository.Common;
using Repository.Proyectos.IRepository;
using Repository.Proyectos.Options;
using Repository.RegulacionesUrbanas.IRepository;
using Repository.RegulacionesUrbanas.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RegulacionesUrbanas.Repository
{
   public class AlineacionEdificacionRepository : TRepository, IAlineacionEdificacionRepository
    {
        private readonly ISession _session;
        public AlineacionEdificacionRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteAlineacionEdificacion(AlineacionEdificacionRU AlineacionEdificacion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(AlineacionEdificacion);
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

        public List<AlineacionEdificacionRU> FindAllAlineacionEdificacions(AlineacionEdificacionSearchOptions options = null)
        {
            var query = _session.Query<AlineacionEdificacionRU>();
            if (options != null)
            {
                if (options.InversionLoteId > 0)
                    query = query.Where(c => c.InversionLote.Id == options.InversionLoteId);

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public AlineacionEdificacionRU GetAlineacionEdificacionbyId(int AlineacionEdificacionId)
        {
            return _session.Query<AlineacionEdificacionRU>().FirstOrDefault(u => u.Id.Equals(AlineacionEdificacionId));
        }



        public StatusResponse InsertAlineacionEdificacion(AlineacionEdificacionRU AlineacionEdificacion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(AlineacionEdificacion);
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

        public StatusResponse UpdateAlineacionEdificacion(AlineacionEdificacionRU AlineacionEdificacion)
        {
            try
            {
                _session.Clear();
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(AlineacionEdificacion);
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

