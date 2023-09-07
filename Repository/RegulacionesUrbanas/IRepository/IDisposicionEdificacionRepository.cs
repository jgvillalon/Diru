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
   public interface IDisposicionEdificacionRepository
    {
        List<DisposicionEdificacionRU> FindAllDisposicionEdificacion(DisposicionEdificacionSearchOptions options);
        StatusResponse InsertDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion);
        StatusResponse UpdateDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion);
        StatusResponse DeleteDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion);
        DisposicionEdificacionRU GetDisposicionEdificacionbyId(int DisposicionEdificacionId);
    }
}
