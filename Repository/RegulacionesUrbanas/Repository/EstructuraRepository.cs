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
   public class EstructuraRepository : TRepository, IEstructuraRepository
    {
        private readonly ISession _session;
        public EstructuraRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteEstructura(Estructuras Estructura)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(Estructura);
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

        public List<Estructuras> FindAllEstructuras(EstructuraSearchOptions options = null)
        {
            var query = _session.Query<Estructuras>();
            if (options != null)
            {
                if (options.InversionLoteId > 0)
                    query = query.Where(c => c.InversionLote.Id == options.InversionLoteId);

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public Estructuras GetEstructurabyId(int EstructuraId)
        {
            return _session.Query<Estructuras>().FirstOrDefault(u => u.Id.Equals(EstructuraId));
        }



        public StatusResponse InsertEstructura(Estructuras Estructura)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(Estructura);
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

        public StatusResponse UpdateEstructura(Estructuras Estructura)
        {
            try
            {
                _session.Clear();
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(Estructura);
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

