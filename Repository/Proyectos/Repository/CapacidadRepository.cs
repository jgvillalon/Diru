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
   public class CapacidadRepository : TRepository, ICapacidadRepository
    {
        private readonly ISession _session;
        public CapacidadRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteCapacidad(Capacidad capacidad)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(capacidad);
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

        public List<Capacidad> FindAllCapacidads(CapacidadSearchOptions options = null)
        {
            var query = _session.Query<Capacidad>();
            if (options != null)
            {
                if (options.ProyectoId > 0)
                    query = query.Where(c => c.Proyecto.Id == options.ProyectoId);

            }
            return query.OrderByDescending(p => p.Id).ToList();
        }

        public Capacidad GetCapacidadbyId(int capacidadId)
        {
            return _session.Query<Capacidad>().FirstOrDefault(u => u.Id.Equals(capacidadId));
        }



        public StatusResponse InsertCapacidad(Capacidad capacidad)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(capacidad);
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

        public StatusResponse UpdateCapacidad(Capacidad capacidad)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(capacidad);
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

