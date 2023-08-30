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
   public interface IAlturaRURepository
    {
        List<AlturaRU> FindAllAlturaRUs(AlturaRUSearchOptions options);
        StatusResponse InsertAlturaRU(AlturaRU AlturaRU);
        StatusResponse UpdateAlturaRU(AlturaRU AlturaRU);
        StatusResponse DeleteAlturaRU(AlturaRU AlturaRU);
        AlturaRU GetAlturaRUbyId(int AlturaRUId);
    }
}
