using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using NHibernate;
using Repository.Common;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using Repository.Nomencladores.Otros.IRepository;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.Repository
{
    public class EstadoTecnicoRepository : TRepository, IEstadoTecnicoRepository
    {
        private readonly ISession _session;
        public EstadoTecnicoRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteEstadoTecnico(EstadoTecnico estadoTecnico)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(estadoTecnico);
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

        public List<EstadoTecnico> FindAllEstadoTecnicos(EstadoTecniccoSearchOptions options = null)
        {
            var query = _session.Query<EstadoTecnico>();
            if (options != null)
            {

                //if (options.Active.HasValue)
                //    query = query.Where(o => o.Active == options.Active.Value);

            }
            return query.ToList();
        }

        public EstadoTecnico GetEstadoTecnicobyId(int estadoTecnicoId)
        {
            return _session.Query<EstadoTecnico>().FirstOrDefault(u => u.Id.Equals(estadoTecnicoId));
        }



        public StatusResponse InsertEstadoTecnico(EstadoTecnico estadoTecnico)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(estadoTecnico);
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

        public StatusResponse UpdateEstadoTecnico(EstadoTecnico estadoTecnico)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(estadoTecnico);
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
