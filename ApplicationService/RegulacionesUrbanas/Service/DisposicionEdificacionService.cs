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
    public class DisposicionEdificacionService : IDisposicionEdificacionService
    {

        private readonly IDisposicionEdificacionRepository _DisposicionEdificacionRepository;

        public DisposicionEdificacionService(IDisposicionEdificacionRepository DisposicionEdificacionRepository)
        {

            _DisposicionEdificacionRepository = DisposicionEdificacionRepository;
        }

        public Response DeleteDisposicionEdificacion(int DisposicionEdificacionId)
        {
            var DisposicionEdificacion = _DisposicionEdificacionRepository.GetDisposicionEdificacionbyId(DisposicionEdificacionId);

            if (DisposicionEdificacion != null)
            {
                var status = _DisposicionEdificacionRepository.DeleteDisposicionEdificacion(DisposicionEdificacion);
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

        public List<DisposicionEdificacionRU> FindAllDisposicionEdificacion(DisposicionEdificacionSearchOptions options = null)
        {
            return _DisposicionEdificacionRepository.FindAllDisposicionEdificacion(options);


        }

        public DisposicionEdificacionRU GetDisposicionEdificacionbyId(int DisposicionEdificacionId)
        {
            return _DisposicionEdificacionRepository.GetDisposicionEdificacionbyId(DisposicionEdificacionId);
        }
        public Response InsertDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion)
        {

            var status = _DisposicionEdificacionRepository.InsertDisposicionEdificacion(DisposicionEdificacion);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion)
        {
            var status = _DisposicionEdificacionRepository.UpdateDisposicionEdificacion(DisposicionEdificacion);
            return new Response
            {
                Status = status
            };
        }
    }
}

