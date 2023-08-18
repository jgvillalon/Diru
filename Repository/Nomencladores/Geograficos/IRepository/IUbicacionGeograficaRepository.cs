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
   public interface IUbicacionGeograficaRepository
    {
        List<UbicacionGeografica> FindAllUbicacionGeograficas(UbicacionGeograficaSearchOptions options);
        StatusResponse InsertUbicacionGeografica(UbicacionGeografica ubicacionGeografica);
        StatusResponse UpdateUbicacionGeografica(UbicacionGeografica ubicacionGeografica);
        StatusResponse DeleteUbicacionGeografica(UbicacionGeografica ubicacionGeografica);
        UbicacionGeografica GetUbicacionGeograficabyId(int ubicacionGeograficaId);
    }
}
