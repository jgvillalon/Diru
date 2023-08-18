using Entity.Entitys.Nomencladores.Otros;
using NHibernate;
using Repository.Common;
using Repository.Nomencladores.Otros.IRepository;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.Repository
{
    public class MetrosRepository : TRepository, IMetrosRepository
    {
        private readonly ISession _session;
        public MetrosRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteMetros(Metros metros)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(metros);
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

        public List<Metros> FindAllMetros(MetrosSearchOptions options = null)
        {
            var query = _session.Query<Metros>();
            if (options != null)
            {

                //if (!string.IsNullOrWhiteSpace(options.Nombre))
                //    query = query.Where(u => u.Nombre.Contains(options.Nombre));

                //if (!string.IsNullOrWhiteSpace(options.Metrosname))
                //    query = query.Where(u => u.Metrosname.Contains(options.Metrosname));

                //if (options.Active.HasValue)
                //    query = query.Where(u => u.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public Metros GetMetrosbyId(int metrosId)
        {
            return _session.Query<Metros>().FirstOrDefault(u => u.Id.Equals(metrosId));
        }



        public StatusResponse InsertMetros(Metros metros)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(metros);
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

        public StatusResponse UpdateMetros(Metros metros)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(metros);
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
