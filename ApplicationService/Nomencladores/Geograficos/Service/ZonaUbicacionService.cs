using ApplicationService.Common;
using ApplicationService.Nomencladores.Geograficos.IService;
using Entity.Entitys.Nomencladores.Geograficos;
using Repository.Common;
using Repository.Nomencladores.Geograficos.IRepository;
using Repository.Nomencladores.Geograficos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Geograficos.Service
{
   public class ZonaUbicacionService : IZonaUbicacionService
    {

        private readonly IZonaUbicacionRepository _zonaUbicacionRepository;
        public ZonaUbicacionService(IZonaUbicacionRepository zonaUbicacionRepository)
        {

            _zonaUbicacionRepository = zonaUbicacionRepository;
        }

        public Response DeleteZonaUbicacion(int zonaUbicacionId)
        {
            var zonaUbicacion = _zonaUbicacionRepository.GetZonaUbicacionbyId(zonaUbicacionId);

            if (zonaUbicacion != null)
            {
                var status = _zonaUbicacionRepository.DeleteZonaUbicacion(zonaUbicacion);
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

        public List<ZonaUbicacion> FindAllZonaUbicacions(ZonaUbicacionSearchOptions options = null)
        {
            return _zonaUbicacionRepository.FindAllZonaUbicacions(options);


        }

        public ZonaUbicacion GetZonaUbicacionbyId(int zonaUbicacionId)
        {
            return _zonaUbicacionRepository.GetZonaUbicacionbyId(zonaUbicacionId);
        }
        public Response InsertZonaUbicacion(ZonaUbicacion zonaUbicacion)
        {

            var status = _zonaUbicacionRepository.InsertZonaUbicacion(zonaUbicacion);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateZonaUbicacion(ZonaUbicacion zonaUbicacion)
        {
            var status = _zonaUbicacionRepository.UpdateZonaUbicacion(zonaUbicacion);
            return new Response
            {
                Status = status
            };
        }
    }
}
