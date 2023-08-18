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
    public class OrganismoService : IOrganismoService
    {

        private readonly IOrganismoRepository _organismoRepository;
        public OrganismoService(IOrganismoRepository organismoRepository)
        {

            _organismoRepository = organismoRepository;
        }

        public Response DeleteOrganismo(int organismoId)
        {
            var organismo = _organismoRepository.GetOrganismobyId(organismoId);

            if (organismo != null)
            {
                var status = _organismoRepository.DeleteOrganismo(organismo);
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

        public List<Organismo> FindAllOrganismos(OrganismoSearchOptions options = null)
        {
            return _organismoRepository.FindAllOrganismos(options);


        }

        public Organismo GetOrganismobyId(int organismoId)
        {
            return _organismoRepository.GetOrganismobyId(organismoId);
        }
        public Response InsertOrganismo(Organismo organismo)
        {

            var status = _organismoRepository.InsertOrganismo(organismo);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateOrganismo(Organismo organismo)
        {
            var status = _organismoRepository.UpdateOrganismo(organismo);
            return new Response
            {
                Status = status
            };
        }
    }
}

