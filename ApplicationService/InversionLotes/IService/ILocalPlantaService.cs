using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.InversionesLotes.Options;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.InversionLotes.IService
{
    public interface ILocalPlantaService
    {
        Response InsertLocalPlanta(LocalPlanta localPlanta);
        Response UpdateLocalPlanta(LocalPlanta localPlanta);
        Response DeleteLocalPlanta(int localPlantaId);
        LocalPlanta GetLocalPlantabyId(int localPlantaId);
        List<LocalPlanta> FindAllLocalPlantas(LocalPlantaSearchOptions options = null);
    }
}
