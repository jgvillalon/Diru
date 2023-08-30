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
   public class AlturaRURepository : TRepository, IAlturaRURepository
    {
        private readonly ISession _session;
        public AlturaRURepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteAlturaRU(AlturaRU AlturaRU)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(AlturaRU);
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

        public List<AlturaRU> FindAllAlturaRUs(AlturaRUSearchOptions options = null)
        {
            var query = _session.Query<AlturaRU>();
            if (options != null)
            {
                if (options.InversionLoteId > 0)
                    query = query.Where(c => c.InversionLote.Id == options.InversionLoteId);

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public AlturaRU GetAlturaRUbyId(int AlturaRUId)
        {
            return _session.Query<AlturaRU>().FirstOrDefault(u => u.Id.Equals(AlturaRUId));
        }



        public StatusResponse InsertAlturaRU(AlturaRU AlturaRU)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(AlturaRU);
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

        public StatusResponse UpdateAlturaRU(AlturaRU AlturaRU)
        {
            try
            {
                _session.Clear();
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(AlturaRU);
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

