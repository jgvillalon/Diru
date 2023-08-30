using ApplicationService.Common;
using ApplicationService.Nomencladores.Generales.IService;
using ApplicationService.Nomencladores.Otros.IService;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
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
    public class RedService : IRedService
    {

        private readonly IRedRepository _RedRepository;

        public RedService(IRedRepository RedRepository)
        {

            _RedRepository = RedRepository;
        }

        public Response DeleteRed(int RedId)
        {
            var Red = _RedRepository.GetRedbyId(RedId);

            if (Red != null)
            {
                var status = _RedRepository.DeleteRed(Red);
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

        public List<Red> FindAllReds(RedSearchOptions options = null)
        {
            return _RedRepository.FindAllReds(options);
        }

        public Red GetRedbyId(int RedId)
        {
            return _RedRepository.GetRedbyId(RedId);
        }
        public Response InsertRed(Red Red)
        {

            var status = _RedRepository.InsertRed(Red);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateRed(Red Red)
        {
            var status = _RedRepository.UpdateRed(Red);
            return new Response
            {
                Status = status
            };
        }
    }
}

