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
    public class AlineacionEdificacionService : IAlineacionEdificacionService
    {

        private readonly IAlineacionEdificacionRepository _AlineacionEdificacionRepository;

        public AlineacionEdificacionService(IAlineacionEdificacionRepository AlineacionEdificacionRepository)
        {

            _AlineacionEdificacionRepository = AlineacionEdificacionRepository;
        }

        public Response DeleteAlineacionEdificacion(int AlineacionEdificacionId)
        {
            var AlineacionEdificacion = _AlineacionEdificacionRepository.GetAlineacionEdificacionbyId(AlineacionEdificacionId);

            if (AlineacionEdificacion != null)
            {
                var status = _AlineacionEdificacionRepository.DeleteAlineacionEdificacion(AlineacionEdificacion);
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

        public List<AlineacionEdificacionRU> FindAllAlineacionEdificacions(AlineacionEdificacionSearchOptions options = null)
        {
            return _AlineacionEdificacionRepository.FindAllAlineacionEdificacions(options);


        }

        public AlineacionEdificacionRU GetAlineacionEdificacionbyId(int AlineacionEdificacionId)
        {
            return _AlineacionEdificacionRepository.GetAlineacionEdificacionbyId(AlineacionEdificacionId);
        }
        public Response InsertAlineacionEdificacion(AlineacionEdificacionRU AlineacionEdificacion)
        {

            var status = _AlineacionEdificacionRepository.InsertAlineacionEdificacion(AlineacionEdificacion);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateAlineacionEdificacion(AlineacionEdificacionRU AlineacionEdificacion)
        {
            var status = _AlineacionEdificacionRepository.UpdateAlineacionEdificacion(AlineacionEdificacion);
            return new Response
            {
                Status = status
            };
        }
    }
}

