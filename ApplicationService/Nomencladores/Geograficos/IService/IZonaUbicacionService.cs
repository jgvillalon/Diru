using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Geograficos;
using Repository.Nomencladores.Geograficos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Geograficos.IService
{
   public interface IZonaUbicacionService
    {
        Response InsertZonaUbicacion(ZonaUbicacion zonaUbicacion);
        Response UpdateZonaUbicacion(ZonaUbicacion zonaUbicacion);
        Response DeleteZonaUbicacion(int zonaUbicacionId);
        ZonaUbicacion GetZonaUbicacionbyId(int zonaUbicacionId);
        List<ZonaUbicacion> FindAllZonaUbicacions(ZonaUbicacionSearchOptions options = null);
    }
}
