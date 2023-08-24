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
    public class EstructuraService : IEstructuraService
    {

        private readonly IEstructuraRepository _EstructuraRepository;

        public EstructuraService(IEstructuraRepository EstructuraRepository)
        {

            _EstructuraRepository = EstructuraRepository;
        }

        public Response DeleteEstructura(int EstructuraId)
        {
            var Estructura = _EstructuraRepository.GetEstructurabyId(EstructuraId);

            if (Estructura != null)
            {
                var status = _EstructuraRepository.DeleteEstructura(Estructura);
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

        public List<Estructuras> FindAllEstructuras(EstructuraSearchOptions options = null)
        {
            return _EstructuraRepository.FindAllEstructuras(options);


        }

        public Estructuras GetEstructurabyId(int EstructuraId)
        {
            return _EstructuraRepository.GetEstructurabyId(EstructuraId);
        }
        public Response InsertEstructura(Estructuras Estructura)
        {

            var status = _EstructuraRepository.InsertEstructura(Estructura);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateEstructura(Estructuras Estructura)
        {
            var status = _EstructuraRepository.UpdateEstructura(Estructura);
            return new Response
            {
                Status = status
            };
        }
    }
}

