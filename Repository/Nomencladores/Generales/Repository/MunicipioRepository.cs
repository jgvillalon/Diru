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
    public class MunicipioRepository : TRepository, IMunicipioRepository
    {
        private readonly ISession _session;
        public MunicipioRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteMunicipio(Municipio municipio)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(municipio);
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

        public List<Municipio> FindAllMunicipios(MunicipioSearchOptions options = null)
        {
            var query = _session.Query<Municipio>();
            if (options != null)
            {

                if (options.Active.HasValue)
                    query = query.Where(m => m.Active == options.Active.Value);
                if (options.Provincia > 0)
                    query = query.Where(m => m.Provincia.Id == options.Provincia);

            }
            return query.ToList();
        }

        public Municipio GetMunicipiobyId(int municipioId)
        {
            return _session.Query<Municipio>().FirstOrDefault(u => u.Id.Equals(municipioId));
        }



        public StatusResponse InsertMunicipio(Municipio municipio)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(municipio);
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

        public StatusResponse UpdateMunicipio(Municipio municipio)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(municipio);
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
