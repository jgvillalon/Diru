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
    public class PaisRepository : TRepository, IPaisRepository
    {
        private readonly ISession _session;
        public PaisRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeletePais(Pais pais)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(pais);
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

        public List<Pais> FindAllPaises(PaisSearchOptions options = null)
        {
            var query = _session.Query<Pais>();
            if (options != null)
            {
                if (options.Active.HasValue)
                    query = query.Where(p => p.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public Pais GetPaisbyId(int paisId)
        {
            return _session.Query<Pais>().FirstOrDefault(u => u.Id.Equals(paisId));
        }



        public StatusResponse InsertPais(Pais pais)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(pais);
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

        public StatusResponse UpdatePais(Pais pais)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(pais);
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

