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
    public class PaisService : IPaisService
    {
        
        private readonly IPaisRepository _paisRepository;
        public PaisService(IPaisRepository paisRepository)
        {

            _paisRepository = paisRepository;
        }

        public Response DeletePais(int paisId)
        {
            var pais = _paisRepository.GetPaisbyId(paisId);

            if (pais != null)
            {
                var status = _paisRepository.DeletePais(pais);
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

        public List<Pais> FindAllPaises(PaisSearchOptions options = null)
        {
            return _paisRepository.FindAllPaises(options);
           

        }

        public Pais GetPaisbyId(int paisId)
        {
            return _paisRepository.GetPaisbyId(paisId);
        }
        public Response InsertPais(Pais pais)
        {
            
            var status = _paisRepository.InsertPais(pais);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdatePais(Pais pais)
        {
            var status = _paisRepository.UpdatePais(pais);
            return new Response
            {
                Status = status
            };
        }
    }
}
