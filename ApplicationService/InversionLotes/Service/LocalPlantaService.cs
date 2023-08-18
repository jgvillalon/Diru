using ApplicationService.Common;
using ApplicationService.InversionLotes.IService;
using ApplicationService.Nomencladores.Generales.IService;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos.InversionesLotes;
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

namespace ApplicationService.InversionLotes.Service
{
    public class LocalPlantaService : ILocalPlantaService
    {

        private readonly ILocalPlantaRepository _localPlantaRepository;

        public LocalPlantaService(ILocalPlantaRepository localPlantaRepository)
        {

            _localPlantaRepository = localPlantaRepository;
        }

        public Response DeleteLocalPlanta(int localPlantaId)
        {
            var localPlanta = _localPlantaRepository.GetLocalPlantabyId(localPlantaId);

            if (localPlanta != null)
            {
                var status = _localPlantaRepository.DeleteLocalPlanta(localPlanta);
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

        public List<LocalPlanta> FindAllLocalPlantas(LocalPlantaSearchOptions options = null)
        {
            return _localPlantaRepository.FindAllLocalPlantas(options);


        }

        public LocalPlanta GetLocalPlantabyId(int localPlantaId)
        {
            return _localPlantaRepository.GetLocalPlantabyId(localPlantaId);
        }
        public Response InsertLocalPlanta(LocalPlanta localPlanta)
        {

            var status = _localPlantaRepository.InsertLocalPlanta(localPlanta);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateLocalPlanta(LocalPlanta localPlanta)
        {
            var status = _localPlantaRepository.UpdateLocalPlanta(localPlanta);
            return new Response
            {
                Status = status
            };
        }
    }
}

