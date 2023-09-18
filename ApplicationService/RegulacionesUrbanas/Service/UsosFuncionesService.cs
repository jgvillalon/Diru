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
    public class UsosFuncionesService : IUsosFuncionesService
    {

        private readonly IUsosFuncionesRepository _UsosFuncionesRepository;

        public UsosFuncionesService(IUsosFuncionesRepository UsosFuncionesRepository)
        {

            _UsosFuncionesRepository = UsosFuncionesRepository;
        }

        public Response DeleteUsosFunciones(int UsosFuncionesId)
        {
            var UsosFunciones = _UsosFuncionesRepository.GetUsosFuncionesbyId(UsosFuncionesId);

            if (UsosFunciones != null)
            {
                var status = _UsosFuncionesRepository.DeleteUsosFunciones(UsosFunciones);
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

        public List<UsosFuncionesRU> FindAllUsosFuncioness(UsosFuncionesSearchOptions options = null)
        {
            return _UsosFuncionesRepository.FindAllUsosFuncioness(options);


        }

        public UsosFuncionesRU GetUsosFuncionesbyId(int UsosFuncionesId)
        {
            return _UsosFuncionesRepository.GetUsosFuncionesbyId(UsosFuncionesId);
        }
        public Response InsertUsosFunciones(UsosFuncionesRU UsosFunciones)
        {

            var status = _UsosFuncionesRepository.InsertUsosFunciones(UsosFunciones);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateUsosFunciones(UsosFuncionesRU UsosFunciones)
        {
            var status = _UsosFuncionesRepository.UpdateUsosFunciones(UsosFunciones);
            return new Response
            {
                Status = status
            };
        }
    }
}

