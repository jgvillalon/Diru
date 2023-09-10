using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using Repository.Common;
using Repository.RegulacionesUrbanas.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RegulacionesUrbanas.IRepository
{
   public interface IFachadaPrincipalRepository
    {
        List<FachadaPrincipalRU> FindAllFachadaPrincipals(FachadaPrincipalSearchOptions options);
        StatusResponse InsertFachadaPrincipal(FachadaPrincipalRU FachadaPrincipal);
        StatusResponse UpdateFachadaPrincipal(FachadaPrincipalRU FachadaPrincipal);
        StatusResponse DeleteFachadaPrincipal(FachadaPrincipalRU FachadaPrincipal);
        FachadaPrincipalRU GetFachadaPrincipalbyId(int FachadaPrincipalId);
    }
}
