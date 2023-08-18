using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using Repository.Nomencladores.Generales.Options;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Otros.IService
{
    public interface IEstadoTecnicoService
    {
        Response InsertEstadoTecnico(EstadoTecnico estadoTecnico);
        Response UpdateEstadoTecnico(EstadoTecnico estadoTecnico);
        Response DeleteEstadoTecnico(int estadoTecnicoId);
        EstadoTecnico GetEstadoTecnicobyId(int estadoTecnicoId);
        List<EstadoTecnico> FindAllEstadoTecnicos(EstadoTecniccoSearchOptions options = null);
    }
}
