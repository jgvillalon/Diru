using ApplicationService.Common;
using ApplicationService.InversionLotes.IService;
using ApplicationService.Nomencladores.Generales.IService;
using ApplicationService.RegulacionesUrbanas.IService;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos.InversionesLotes;
using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using Repository.Common;
using Repository.InversionesLotes.IRepository;
using Repository.InversionesLotes.Options;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using Repository.RegulacionesUrbanas.IRepository;
using Repository.RegulacionesUrbanas.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.RegulacionesUrbanas.Service
{
    public class AlturaRUService : IAlturaRUService
    {

        private readonly IAlturaRURepository _AlturaRURepository;

        public AlturaRUService(IAlturaRURepository AlturaRURepository)
        {

            _AlturaRURepository = AlturaRURepository;
        }

        public Response DeleteAlturaRU(int AlturaRUId)
        {
            var AlturaRU = _AlturaRURepository.GetAlturaRUbyId(AlturaRUId);

            if (AlturaRU != null)
            {
                var status = _AlturaRURepository.DeleteAlturaRU(AlturaRU);
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

        public List<AlturaRU> FindAllAlturaRUs(AlturaRUSearchOptions options = null)
        {
            return _AlturaRURepository.FindAllAlturaRUs(options);


        }

        public AlturaRU GetAlturaRUbyId(int AlturaRUId)
        {
            return _AlturaRURepository.GetAlturaRUbyId(AlturaRUId);
        }
        public Response InsertAlturaRU(AlturaRU AlturaRU)
        {

            var status = _AlturaRURepository.InsertAlturaRU(AlturaRU);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateAlturaRU(AlturaRU AlturaRU)
        {
            var status = _AlturaRURepository.UpdateAlturaRU(AlturaRU);
            return new Response
            {
                Status = status
            };
        }
    }
}

