using Entity.Entitys.Nomencladores.Geograficos;
using Repository.Common;
using Repository.Nomencladores.Geograficos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Geograficos.IRepository
{
    public interface IZonaUbicacionRepository
    {
        List<ZonaUbicacion> FindAllZonaUbicacions(ZonaUbicacionSearchOptions options);
        StatusResponse InsertZonaUbicacion(ZonaUbicacion zonaUbicacion);
        StatusResponse UpdateZonaUbicacion(ZonaUbicacion zonaUbicacion);
        StatusResponse DeleteZonaUbicacion(ZonaUbicacion zonaUbicacion);
        ZonaUbicacion GetZonaUbicacionbyId(int zonaUbicacionId);
    }
}
