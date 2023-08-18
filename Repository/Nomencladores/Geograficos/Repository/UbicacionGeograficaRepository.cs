using Entity.Entitys.Nomencladores.Geograficos;
using NHibernate;
using Repository.Common;
using Repository.Nomencladores.Geograficos.IRepository;
using Repository.Nomencladores.Geograficos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Geograficos.Repository
{
   public class UbicacionGeograficaRepository : TRepository, IUbicacionGeograficaRepository
    {
        private readonly ISession _session;
        public UbicacionGeograficaRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteUbicacionGeografica(UbicacionGeografica ubicacionGeografica)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(ubicacionGeografica);
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

        public List<UbicacionGeografica> FindAllUbicacionGeograficas(UbicacionGeograficaSearchOptions options = null)
        {
            var query = _session.Query<UbicacionGeografica>();
            if (options != null)
            {

                //if (!string.IsNullOrWhiteSpace(options.Nombre))
                //    query = query.Where(u => u.Nombre.Contains(options.Nombre));

                //if (!string.IsNullOrWhiteSpace(options.UbicacionGeograficaname))
                //    query = query.Where(u => u.UbicacionGeograficaname.Contains(options.UbicacionGeograficaname));

                //if (options.Active.HasValue)
                //    query = query.Where(u => u.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public UbicacionGeografica GetUbicacionGeograficabyId(int ubicacionGeograficaId)
        {
            return _session.Query<UbicacionGeografica>().FirstOrDefault(u => u.Id.Equals(ubicacionGeograficaId));
        }



        public StatusResponse InsertUbicacionGeografica(UbicacionGeografica ubicacionGeografica)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(ubicacionGeografica);
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

        public StatusResponse UpdateUbicacionGeografica(UbicacionGeografica ubicacionGeografica)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(ubicacionGeografica);
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
