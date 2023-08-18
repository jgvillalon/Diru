using ApplicationService.Common;
using ApplicationService.Nomencladores.Generales.IService;
using ApplicationService.Nomencladores.Otros.IService;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using Repository.Common;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using Repository.Nomencladores.Otros.IRepository;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Otros.Service
{
    public class EstadoTecnicoService : IEstadoTecnicoService
    {

        private readonly IEstadoTecnicoRepository _estadoTecnicoRepository;

        public EstadoTecnicoService(IEstadoTecnicoRepository estadoTecnicoRepository)
        {

            _estadoTecnicoRepository = estadoTecnicoRepository;
        }

        public Response DeleteEstadoTecnico(int estadoTecnicoId)
        {
            var estadoTecnico = _estadoTecnicoRepository.GetEstadoTecnicobyId(estadoTecnicoId);

            if (estadoTecnico != null)
            {
                var status = _estadoTecnicoRepository.DeleteEstadoTecnico(estadoTecnico);
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

        public List<EstadoTecnico> FindAllEstadoTecnicos(EstadoTecniccoSearchOptions options = null)
        {
            return _estadoTecnicoRepository.FindAllEstadoTecnicos(options);


        }

        public EstadoTecnico GetEstadoTecnicobyId(int estadoTecnicoId)
        {
            return _estadoTecnicoRepository.GetEstadoTecnicobyId(estadoTecnicoId);
        }
        public Response InsertEstadoTecnico(EstadoTecnico estadoTecnico)
        {

            var status = _estadoTecnicoRepository.InsertEstadoTecnico(estadoTecnico);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateEstadoTecnico(EstadoTecnico estadoTecnico)
        {
            var status = _estadoTecnicoRepository.UpdateEstadoTecnico(estadoTecnico);
            return new Response
            {
                Status = status
            };
        }
    }
}

