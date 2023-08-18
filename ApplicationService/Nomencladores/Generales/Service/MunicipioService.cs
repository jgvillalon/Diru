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
    public class MunicipioService : IMunicipioService
    {

        private readonly IMunicipioRepository _municipioRepository;
        public MunicipioService(IMunicipioRepository municipioRepository)
        {

            _municipioRepository = municipioRepository;
        }

        public Response DeleteMunicipio(int municipioId)
        {
            var municipio = _municipioRepository.GetMunicipiobyId(municipioId);

            if (municipio != null)
            {
                var status = _municipioRepository.DeleteMunicipio(municipio);
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

        public List<Municipio> FindAllMunicipios(MunicipioSearchOptions options = null)
        {
            return _municipioRepository.FindAllMunicipios(options);


        }

        public Municipio GetMunicipiobyId(int municipioId)
        {
            return _municipioRepository.GetMunicipiobyId(municipioId);
        }
        public Response InsertMunicipio(Municipio municipio)
        {

            var status = _municipioRepository.InsertMunicipio(municipio);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateMunicipio(Municipio municipio)
        {
            var status = _municipioRepository.UpdateMunicipio(municipio);
            return new Response
            {
                Status = status
            };
        }
    }
}
