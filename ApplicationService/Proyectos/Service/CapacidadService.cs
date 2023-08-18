using ApplicationService.Common;
using ApplicationService.Proyectos.IService;
using Entity.Entitys.Proyectos;
using Repository.Common;
using Repository.Proyectos.IRepository;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Proyectos.Service
{
    public class CapacidadService : ICapacidadService
    {

        private readonly ICapacidadRepository _capacidadRepository;
        public CapacidadService(ICapacidadRepository capacidadRepository)
        {

            _capacidadRepository = capacidadRepository;
        }

        public Response DeleteCapacidad(int capacidadId)
        {
            var capacidad = _capacidadRepository.GetCapacidadbyId(capacidadId);

            if (capacidad != null)
            {
                var status = _capacidadRepository.DeleteCapacidad(capacidad);
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

        public List<Capacidad> FindAllCapacidads(CapacidadSearchOptions options = null)
        {
            return _capacidadRepository.FindAllCapacidads(options);


        }

        public Capacidad GetCapacidadbyId(int capacidadId)
        {
            return _capacidadRepository.GetCapacidadbyId(capacidadId);
        }
        public Response InsertCapacidad(Capacidad capacidad)
        {

            var status = _capacidadRepository.InsertCapacidad(capacidad);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateCapacidad(Capacidad capacidad)
        {
            var status = _capacidadRepository.UpdateCapacidad(capacidad);
            return new Response
            {
                Status = status
            };
        }
    }
}


