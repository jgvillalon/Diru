using ApplicationService.Common;
using ApplicationService.Nomencladores.Geograficos.IService;
using Entity.Entitys.Nomencladores.Geograficos;
using Repository.Common;
using Repository.Nomencladores.Geograficos.IRepository;
using Repository.Nomencladores.Geograficos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Geograficos.Service
{
   public class UbicacionGeograficaService : IUbicacionGeograficaService
    {

        private readonly IUbicacionGeograficaRepository _ubicacionGeograficaRepository;
        public UbicacionGeograficaService(IUbicacionGeograficaRepository ubicacionGeograficaRepository)
        {

            _ubicacionGeograficaRepository = ubicacionGeograficaRepository;
        }

        public Response DeleteUbicacionGeografica(int ubicacionGeograficaId)
        {
            var ubicacionGeografica = _ubicacionGeograficaRepository.GetUbicacionGeograficabyId(ubicacionGeograficaId);

            if (ubicacionGeografica != null)
            {
                var status = _ubicacionGeograficaRepository.DeleteUbicacionGeografica(ubicacionGeografica);
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

        public List<UbicacionGeografica> FindAllUbicacionGeograficas(UbicacionGeograficaSearchOptions options = null)
        {
            return _ubicacionGeograficaRepository.FindAllUbicacionGeograficas(options);


        }

        public UbicacionGeografica GetUbicacionGeograficabyId(int ubicacionGeograficaId)
        {
            return _ubicacionGeograficaRepository.GetUbicacionGeograficabyId(ubicacionGeograficaId);
        }
        public Response InsertUbicacionGeografica(UbicacionGeografica ubicacionGeografica)
        {

            var status = _ubicacionGeograficaRepository.InsertUbicacionGeografica(ubicacionGeografica);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateUbicacionGeografica(UbicacionGeografica ubicacionGeografica)
        {
            var status = _ubicacionGeograficaRepository.UpdateUbicacionGeografica(ubicacionGeografica);
            return new Response
            {
                Status = status
            };
        }
    }
}
