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
    public class ProvinciaService : IProvinciaService
    {

        private readonly IProvinciaRepository _provinciaRepository;
        public ProvinciaService(IProvinciaRepository provinciaRepository)
        {

            _provinciaRepository = provinciaRepository;
        }

        public Response DeleteProvincia(int provinciaId)
        {
            var provincia = _provinciaRepository.GetProvinciabyId(provinciaId);

            if (provincia != null)
            {
                var status = _provinciaRepository.DeleteProvincia(provincia);
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

        public List<Provincia> FindAllProvincias(ProvinciaSearchOptions options = null)
        {
            return _provinciaRepository.FindAllProvincias(options);


        }

        public Provincia GetProvinciabyId(int provinciaId)
        {
            return _provinciaRepository.GetProvinciabyId(provinciaId);
        }
        public Response InsertProvincia(Provincia provincia)
        {

            var status = _provinciaRepository.InsertProvincia(provincia);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateProvincia(Provincia provincia)
        {
            var status = _provinciaRepository.UpdateProvincia(provincia);
            return new Response
            {
                Status = status
            };
        }
    }
}

