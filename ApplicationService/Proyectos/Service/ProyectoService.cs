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
   public class ProyectoService : IProyectoService
    {

        private readonly IProyectoRepository _proyectoRepository;
        public ProyectoService(IProyectoRepository proyectoRepository)
        {

            _proyectoRepository = proyectoRepository;
        }

        public Response DeleteProyecto(int proyectoId)
        {
            var proyecto = _proyectoRepository.GetProyectobyId(proyectoId);

            if (proyecto != null)
            {
                var status = _proyectoRepository.DeleteProyecto(proyecto);
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

        public List<Proyecto> FindAllProyectos(ProyectoSearchOptions options = null)
        {
            return _proyectoRepository.FindAllProyectos(options);


        }

        public Proyecto GetProyectobyId(int proyectoId)
        {
            return _proyectoRepository.GetProyectobyId(proyectoId);
        }
        public Response InsertProyecto(Proyecto proyecto)
        {

            var status = _proyectoRepository.InsertProyecto(proyecto);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateProyecto(Proyecto proyecto)
        {
            var status = _proyectoRepository.UpdateProyecto(proyecto);
            return new Response
            {
                Status = status
            };
        }
    }
}


