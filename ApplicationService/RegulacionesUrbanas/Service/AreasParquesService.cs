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
    public class AreasParquesService : IAreasParquesService
    {

        private readonly IAreasParquesRepository _AreasParquesRepository;

        public AreasParquesService(IAreasParquesRepository AreasParquesRepository)
        {

            _AreasParquesRepository = AreasParquesRepository;
        }

        public Response DeleteAreasParques(int AreasParquesId)
        {
            var AreasParques = _AreasParquesRepository.GetAreasParquesbyId(AreasParquesId);

            if (AreasParques != null)
            {
                var status = _AreasParquesRepository.DeleteAreasParques(AreasParques);
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

        public List<AreasParquesRU> FindAllAreasParquess(AreasParquesSearchOptions options = null)
        {
            return _AreasParquesRepository.FindAllAreasParquess(options);


        }

        public AreasParquesRU GetAreasParquesbyId(int AreasParquesId)
        {
            return _AreasParquesRepository.GetAreasParquesbyId(AreasParquesId);
        }
        public Response InsertAreasParques(AreasParquesRU AreasParques)
        {

            var status = _AreasParquesRepository.InsertAreasParques(AreasParques);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateAreasParques(AreasParquesRU AreasParques)
        {
            var status = _AreasParquesRepository.UpdateAreasParques(AreasParques);
            return new Response
            {
                Status = status
            };
        }
    }
}

