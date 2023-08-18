using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Otros.IService
{
    public interface IPlantaService
    {
        Response InsertPlanta(Planta planta);
        Response UpdatePlanta(Planta planta);
        Response DeletePlanta(int plantaId);
        Planta GetPlantabyId(int plantaId);
        List<Planta> FindAllPlantas(PlantaSearchOptions options = null);
    }
}
