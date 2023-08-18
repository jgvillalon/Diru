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
    public class ProvinciaRepository : TRepository, IProvinciaRepository
    {
        private readonly ISession _session;
        public ProvinciaRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteProvincia(Provincia provincia)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(provincia);
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

        public List<Provincia> FindAllProvincias(ProvinciaSearchOptions options = null)
        {
            var query = _session.Query<Provincia>();
            if (options != null)
            {

                if (options.Active.HasValue)
                    query = query.Where(p => p.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public Provincia GetProvinciabyId(int provinciaId)
        {
            return _session.Query<Provincia>().FirstOrDefault(u => u.Id.Equals(provinciaId));
        }



        public StatusResponse InsertProvincia(Provincia provincia)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(provincia);
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

        public StatusResponse UpdateProvincia(Provincia provincia)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(provincia);
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
