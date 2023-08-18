using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos.InversionesLotes;
using NHibernate;
using Repository.Common;
using Repository.InversionesLotes.IRepository;
using Repository.InversionesLotes.Options;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InversionesLotes.Repository
{
    public class LocalPlantaRepository : TRepository, ILocalPlantaRepository
    {
        private readonly ISession _session;
        public LocalPlantaRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeleteLocalPlanta(LocalPlanta localPlanta)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(localPlanta);
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

        public List<LocalPlanta> FindAllLocalPlantas(LocalPlantaSearchOptions options = null)
        {
            var query = _session.Query<LocalPlanta>();
            if (options != null)
            {

                if (options.PlantaId > 0)
                    query = query.Where(o => o.Planta.Id == options.PlantaId);

            }
            return query.ToList();
        }

        public LocalPlanta GetLocalPlantabyId(int localPlantaId)
        {
            return _session.Query<LocalPlanta>().FirstOrDefault(u => u.Id.Equals(localPlantaId));
        }



        public StatusResponse InsertLocalPlanta(LocalPlanta localPlanta)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(localPlanta);
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

        public StatusResponse UpdateLocalPlanta(LocalPlanta localPlanta)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(localPlanta);
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
