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
   public class UsosFuncionesRepository : TRepository, IUsosFuncionesRepository
    {
        private readonly ISession _session;
        public UsosFuncionesRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteUsosFunciones(UsosFuncionesRU UsosFunciones)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(UsosFunciones);
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

        public List<UsosFuncionesRU> FindAllUsosFuncioness(UsosFuncionesSearchOptions options = null)
        {
            var query = _session.Query<UsosFuncionesRU>();
            if (options != null)
            {
                if (options.InversionLoteId > 0)
                    query = query.Where(c => c.InversionLote.Id == options.InversionLoteId);

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public UsosFuncionesRU GetUsosFuncionesbyId(int UsosFuncionesId)
        {
            return _session.Query<UsosFuncionesRU>().FirstOrDefault(u => u.Id.Equals(UsosFuncionesId));
        }



        public StatusResponse InsertUsosFunciones(UsosFuncionesRU UsosFunciones)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(UsosFunciones);
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

        public StatusResponse UpdateUsosFunciones(UsosFuncionesRU UsosFunciones)
        {
            try
            {
                _session.Clear();
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(UsosFunciones);
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

