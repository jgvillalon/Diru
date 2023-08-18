using Entity.Entitys.Proyectos;
using NHibernate;
using Repository.Common;
using Repository.Proyectos.IRepository;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Proyectos.Repository
{
   public class ProyectoRepository : TRepository, IProyectoRepository
    {
        private readonly ISession _session;
        public ProyectoRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteProyecto(Proyecto proyecto)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(proyecto);
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

        public List<Proyecto> FindAllProyectos(ProyectoSearchOptions options = null)
        {
            var query = _session.Query<Proyecto>();
            if (options != null)
            {

                if (options.Active.HasValue)
                    query = query.Where(o => o.Active == options.Active.Value);

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public Proyecto GetProyectobyId(int proyectoId)
        {
            return _session.Query<Proyecto>().FirstOrDefault(u => u.Id.Equals(proyectoId));
        }



        public StatusResponse InsertProyecto(Proyecto proyecto)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(proyecto);
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

        public StatusResponse UpdateProyecto(Proyecto proyecto)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(proyecto);
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
