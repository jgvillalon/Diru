using ApplicationService.Common;
using ApplicationService.Nomencladores.Otros.IService;
using Entity.Entitys.Nomencladores.Otros;
using Repository.Common;
using Repository.Nomencladores.Otros.IRepository;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Otros.Service
{
    public class MetrosService : IMetrosService
    {

        private readonly IMetrosRepository _metrosRepository;
        public MetrosService(IMetrosRepository metrosRepository)
        {

            _metrosRepository = metrosRepository;
        }

        public Response DeleteMetros(int metrosId)
        {
            var metros = _metrosRepository.GetMetrosbyId(metrosId);

            if (metros != null)
            {
                var status = _metrosRepository.DeleteMetros(metros);
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

        public List<Metros> FindAllMetros(MetrosSearchOptions options = null)
        {
            return _metrosRepository.FindAllMetros(options);


        }

        public Metros GetMetrosbyId(int metrosId)
        {
            return _metrosRepository.GetMetrosbyId(metrosId);
        }
        public Response InsertMetros(Metros metros)
        {

            var status = _metrosRepository.InsertMetros(metros);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateMetros(Metros metros)
        {
            var status = _metrosRepository.UpdateMetros(metros);
            return new Response
            {
                Status = status
            };
        }
    }
}

