using ApplicationService.Common;
using ApplicationService.Nomencladores.Otros.IService;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Common;
using Repository.Nomencladores.Otros.IRepository;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Otros.Service
{
    public class PlantaService : IPlantaService
    {

        private readonly IPlantaRepository _plantaRepository;
        public PlantaService(IPlantaRepository plantaRepository)
        {

            _plantaRepository = plantaRepository;
        }

        public Response DeletePlanta(int plantaId)
        {
            var planta = _plantaRepository.GetPlantabyId(plantaId);

            if (planta != null)
            {
                var status = _plantaRepository.DeletePlanta(planta);
                return new Response
                {
                    Status = status
                };

            }
            return new Response
            {
                Status = StatusResponse.NotFound
            };
        }

        public List<Planta> FindAllPlantas(PlantaSearchOptions options = null)
        {
            return _plantaRepository.FindAllPlantas(options);


        }

        public Planta GetPlantabyId(int plantaId)
        {
            return _plantaRepository.GetPlantabyId(plantaId);
        }
        public Response InsertPlanta(Planta planta)
        {

            var status = _plantaRepository.InsertPlanta(planta);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdatePlanta(Planta planta)
        {
            var status = _plantaRepository.UpdatePlanta(planta);
            return new Response
            {
                Status = status
            };
        }
    }
}

