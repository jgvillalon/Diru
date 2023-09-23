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
   public interface IAreasParquesRepository
    {
        List<AreasParquesRU> FindAllAreasParquess(AreasParquesSearchOptions options);
        StatusResponse InsertAreasParques(AreasParquesRU AreasParques);
        StatusResponse UpdateAreasParques(AreasParquesRU AreasParques);
        StatusResponse DeleteAreasParques(AreasParquesRU AreasParques);
        AreasParquesRU GetAreasParquesbyId(int AreasParquesId);
    }
}
