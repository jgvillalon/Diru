using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
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
    public class PlantaRepository : TRepository, IPlantaRepository
    {
        private readonly ISession _session;
        public PlantaRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public StatusResponse DeletePlanta(Planta planta)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(planta);
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

        public List<Planta> FindAllPlantas(PlantaSearchOptions options = null)
        {
            var query = _session.Query<Planta>();
            if (options != null)
            {

                if (options.InversionLoteId > 0)
                    query = query.Where(u => u.InversionLote.Id == options.InversionLoteId);

                //if (!string.IsNullOrWhiteSpace(options.Plantaname))
                //    query = query.Where(u => u.Plantaname.Contains(options.Plantaname));

                if (options.Nuevo.HasValue)
                    query = query.Where(u => u.Nuevo == options.Nuevo.Value);

            }
            return query.OrderBy(p => p.Id).ToList();
        }

        public Planta GetPlantabyId(int plantaId)
        {
            return _session.Query<Planta>().FirstOrDefault(u => u.Id.Equals(plantaId));
        }



        public StatusResponse InsertPlanta(Planta planta)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(planta);
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

        public StatusResponse UpdatePlanta(Planta planta)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(planta);
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
