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
    public class OrganismoRepository : TRepository, IOrganismoRepository
    {
        private readonly ISession _session;
        public OrganismoRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteOrganismo(Organismo organismo)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(organismo);
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

        public List<Organismo> FindAllOrganismos(OrganismoSearchOptions options = null)
        {
            var query = _session.Query<Organismo>();
            if (options != null)
            {

                if (options.Active.HasValue)
                    query = query.Where(o => o.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public Organismo GetOrganismobyId(int organismoId)
        {
            return _session.Query<Organismo>().FirstOrDefault(u => u.Id.Equals(organismoId));
        }



        public StatusResponse InsertOrganismo(Organismo organismo)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(organismo);
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

        public StatusResponse UpdateOrganismo(Organismo organismo)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(organismo);
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
