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
   public interface IUbicacionGeograficaService
    {
        Response InsertUbicacionGeografica(UbicacionGeografica ubicacionGeografica);
        Response UpdateUbicacionGeografica(UbicacionGeografica ubicacionGeografica);
        Response DeleteUbicacionGeografica(int ubicacionGeograficaId);
        UbicacionGeografica GetUbicacionGeograficabyId(int ubicacionGeograficaId);
        List<UbicacionGeografica> FindAllUbicacionGeograficas(UbicacionGeograficaSearchOptions options = null);
    }
}
