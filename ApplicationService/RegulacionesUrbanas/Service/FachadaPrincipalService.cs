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
    public class FachadaPrincipalService : IFachadaPrincipalService
    {

        private readonly IFachadaPrincipalRepository _FachadaPrincipalRepository;

        public FachadaPrincipalService(IFachadaPrincipalRepository FachadaPrincipalRepository)
        {

            _FachadaPrincipalRepository = FachadaPrincipalRepository;
        }

        public Response DeleteFachadaPrincipal(int FachadaPrincipalId)
        {
            var FachadaPrincipal = _FachadaPrincipalRepository.GetFachadaPrincipalbyId(FachadaPrincipalId);

            if (FachadaPrincipal != null)
            {
                var status = _FachadaPrincipalRepository.DeleteFachadaPrincipal(FachadaPrincipal);
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

        public List<FachadaPrincipalRU> FindAllFachadaPrincipals(FachadaPrincipalSearchOptions options = null)
        {
            return _FachadaPrincipalRepository.FindAllFachadaPrincipals(options);


        }

        public FachadaPrincipalRU GetFachadaPrincipalbyId(int FachadaPrincipalId)
        {
            return _FachadaPrincipalRepository.GetFachadaPrincipalbyId(FachadaPrincipalId);
        }
        public Response InsertFachadaPrincipal(FachadaPrincipalRU FachadaPrincipal)
        {

            var status = _FachadaPrincipalRepository.InsertFachadaPrincipal(FachadaPrincipal);
            return new Response
            {
                Status = status
            };
        }

        public Response UpdateFachadaPrincipal(FachadaPrincipalRU FachadaPrincipal)
        {
            var status = _FachadaPrincipalRepository.UpdateFachadaPrincipal(FachadaPrincipal);
            return new Response
            {
                Status = status
            };
        }
    }
}

