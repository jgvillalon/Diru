using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos.InversionesLotes;
using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using Repository.InversionesLotes.Options;
using Repository.Nomencladores.Generales.Options;
using Repository.RegulacionesUrbanas.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.RegulacionesUrbanas.IService
{
    public interface IAlturaRUService
    {
        Response InsertAlturaRU(AlturaRU AlturaRU);
        Response UpdateAlturaRU(AlturaRU AlturaRU);
        Response DeleteAlturaRU(int AlturaRUId);
        AlturaRU GetAlturaRUbyId(int AlturaRUId);
        List<AlturaRU> FindAllAlturaRUs(AlturaRUSearchOptions options = null);
    }
}
