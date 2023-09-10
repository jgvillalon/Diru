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
   public class FachadaPrincipalRepository : TRepository, IFachadaPrincipalRepository
    {
        private readonly ISession _session;
        public FachadaPrincipalRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteFachadaPrincipal(FachadaPrincipalRU FachadaPrincipal)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(FachadaPrincipal);
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

        public List<FachadaPrincipalRU> FindAllFachadaPrincipals(FachadaPrincipalSearchOptions options = null)
        {
            var query = _session.Query<FachadaPrincipalRU>();
            if (options != null)
            {
                if (options.InversionLoteId > 0)
                    query = query.Where(c => c.InversionLote.Id == options.InversionLoteId);

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public FachadaPrincipalRU GetFachadaPrincipalbyId(int FachadaPrincipalId)
        {
            return _session.Query<FachadaPrincipalRU>().FirstOrDefault(u => u.Id.Equals(FachadaPrincipalId));
        }



        public StatusResponse InsertFachadaPrincipal(FachadaPrincipalRU FachadaPrincipal)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(FachadaPrincipal);
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

        public StatusResponse UpdateFachadaPrincipal(FachadaPrincipalRU FachadaPrincipal)
        {
            try
            {
                _session.Clear();
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(FachadaPrincipal);
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

