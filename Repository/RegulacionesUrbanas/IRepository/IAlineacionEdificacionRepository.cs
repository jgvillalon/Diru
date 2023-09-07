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
   public interface IAlineacionEdificacionRepository
    {
        List<AlineacionEdificacionRU> FindAllAlineacionEdificacions(AlineacionEdificacionSearchOptions options);
        StatusResponse InsertAlineacionEdificacion(AlineacionEdificacionRU AlineacionEdificacion);
        StatusResponse UpdateAlineacionEdificacion(AlineacionEdificacionRU AlineacionEdificacion);
        StatusResponse DeleteAlineacionEdificacion(AlineacionEdificacionRU AlineacionEdificacion);
        AlineacionEdificacionRU GetAlineacionEdificacionbyId(int AlineacionEdificacionId);
    }
}
