using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Common;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.IRepository
{
    public interface IPlantaRepository
    {
        List<Planta> FindAllPlantas(PlantaSearchOptions options);
        StatusResponse InsertPlanta(Planta planta);
        StatusResponse UpdatePlanta(Planta planta);
        StatusResponse DeletePlanta(Planta planta);
        Planta GetPlantabyId(int plantaId);
    }
}
