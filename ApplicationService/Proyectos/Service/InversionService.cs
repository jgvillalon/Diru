using ApplicationService.Common;
using ApplicationService.Inversions.IService;
using Entity.Entitys.Proyectos;
using Repository.Common;
using Repository.Inversions.IRepository;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Inversions.Service
{
   public class InversionService : IInversionService
    {

        private readonly IInversionRepository _inversionRepository;
        public InversionService(IInversionRepository inversionRepository)
        {

            _inversionRepository = inversionRepository;
        }

        public Response DeleteInversion(int inversionId)
        {
            var inversion = _inversionRepository.GetInversionbyId(inversionId);

            if (inversion != null)
            {
                var status = _inversionRepository.DeleteInversion(inversion);
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

        public List<Inversion> FindAllInversions(InversionSearchOptions options = null)
        {
            return _inversionRepository.FindAllInversions(options);


        }

        public Inversion GetInversionbyId(int inversionId)
        {
            return _inversionRepository.GetInversionbyId(inversionId);
        }
        public Response InsertInversion(Inversion inversion)
        {

            var status = _inversionRepository.InsertInversion(inversion);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateInversion(Inversion inversion)
        {
            var status = _inversionRepository.UpdateInversion(inversion);
            return new Response
            {
                Status = status
            };
        }
    }
}

