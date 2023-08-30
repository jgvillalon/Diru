using ApplicationService.Common;
using ApplicationService.Nomencladores.Otros.IService;
using Entity.Entitys.Nomencladores.Otros;
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
    public class AccionPrecioService : IAccionPrecioService
    {

        private readonly IAccionPrecioRepository _accionPrecioRepository;

        public AccionPrecioService(IAccionPrecioRepository accionPrecioRepository)
        {

            _accionPrecioRepository = accionPrecioRepository;
        }

        public Response DeleteAccionPrecio(int accionPrecioId)
        {
            var accionPrecio = _accionPrecioRepository.GetAccionPreciobyId(accionPrecioId);

            if (accionPrecio != null)
            {
                var status = _accionPrecioRepository.DeleteAccionPrecio(accionPrecio);
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

        public List<AccionPrecio> FindAllAccionPrecios(AccionPrecioSearchOptions options = null)
        {
            return _accionPrecioRepository.FindAllAccionPrecios(options);


        }

        public AccionPrecio GetAccionPreciobyId(int accionPrecioId)
        {
            return _accionPrecioRepository.GetAccionPreciobyId(accionPrecioId);
        }
        public Response InsertAccionPrecio(AccionPrecio accionPrecio)
        {

            var status = _accionPrecioRepository.InsertAccionPrecio(accionPrecio);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateAccionPrecio(AccionPrecio accionPrecio)
        {
            var status = _accionPrecioRepository.UpdateAccionPrecio(accionPrecio);
            return new Response
            {
                Status = status
            };
        }
    }
}

