using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos.InversionesLotes;
using Repository.Common;
using Repository.InversionesLotes.Options;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InversionesLotes.IRepository
{
    public interface ILocalPlantaRepository
    {
        List<LocalPlanta> FindAllLocalPlantas(LocalPlantaSearchOptions options);
        StatusResponse InsertLocalPlanta(LocalPlanta cliente);
        StatusResponse UpdateLocalPlanta(LocalPlanta cliente);
        StatusResponse DeleteLocalPlanta(LocalPlanta cliente);
        LocalPlanta GetLocalPlantabyId(int clienteId);
    }
}
