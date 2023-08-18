using ApplicationService.Common;
using ApplicationService.Nomencladores.Generales.IService;
using Entity.Entitys.Nomencladores.Generales;
using Repository.Common;
using Repository.Nomencladores.Generales.IRepository;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Generales.Service
{
   public class EntidadService : IEntidadService
    {

        private readonly IEntidadRepository _entidadRepository;
        public EntidadService(IEntidadRepository entidadRepository)
        {

            _entidadRepository = entidadRepository;
        }

        public Response DeleteEntidad(int entidadId)
        {
            var entidad = _entidadRepository.GetEntidadbyId(entidadId);

            if (entidad != null)
            {
                var status = _entidadRepository.DeleteEntidad(entidad);
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

        public List<Entidad> FindAllEntidades(EntidadSearchOptions options = null)
        {
            return _entidadRepository.FindAllEntidades(options);


        }

        public Entidad GetEntidadbyId(int entidadId)
        {
            return _entidadRepository.GetEntidadbyId(entidadId);
        }
        public Response InsertEntidad(Entidad entidad)
        {

            var status = _entidadRepository.InsertEntidad(entidad);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateEntidad(Entidad entidad)
        {
            var status = _entidadRepository.UpdateEntidad(entidad);
            return new Response
            {
                Status = status
            };
        }
    }
}

