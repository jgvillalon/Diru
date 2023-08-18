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
    public class LocalService : ILocalService
    {

        private readonly ILocalRepository _localRepository;

        public LocalService(ILocalRepository localRepository)
        {

            _localRepository = localRepository;
        }

        public Response DeleteLocal(int localId)
        {
            var local = _localRepository.GetLocalbyId(localId);

            if (local != null)
            {
                var status = _localRepository.DeleteLocal(local);
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

        public List<Local> FindAllLocals(LocalSearchOptions options = null)
        {
            return _localRepository.FindAllLocals(options);


        }

        public Local GetLocalbyId(int localId)
        {
            return _localRepository.GetLocalbyId(localId);
        }
        public Response InsertLocal(Local local)
        {

            var status = _localRepository.InsertLocal(local);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateLocal(Local local)
        {
            var status = _localRepository.UpdateLocal(local);
            return new Response
            {
                Status = status
            };
        }
    }
}


