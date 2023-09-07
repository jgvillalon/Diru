
using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using NHibernate;
using Repository.Common;
using Repository.RegulacionesUrbanas.IRepository;
using Repository.RegulacionesUrbanas.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RegulacionesUrbanas.Repository
{
   public class DisposicionEdificacionRepository : TRepository, IDisposicionEdificacionRepository
    {
        private readonly ISession _session;
        public DisposicionEdificacionRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(DisposicionEdificacion);
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

        public List<DisposicionEdificacionRU> FindAllDisposicionEdificacion(DisposicionEdificacionSearchOptions options = null)
        {
            var query = _session.Query<DisposicionEdificacionRU>();
            if (options != null)
            {
                if (options.InversionLoteId > 0)
                    query = query.Where(c => c.InversionLote.Id == options.InversionLoteId);

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public DisposicionEdificacionRU GetDisposicionEdificacionbyId(int DisposicionEdificacionId)
        {
            return _session.Query<DisposicionEdificacionRU>().FirstOrDefault(u => u.Id.Equals(DisposicionEdificacionId));
        }



        public StatusResponse InsertDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(DisposicionEdificacion);
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

        public StatusResponse UpdateDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion)
        {
            try
            {
                _session.Clear();
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(DisposicionEdificacion);
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

