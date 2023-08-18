using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using Repository.Common;
using Repository.Nomencladores.Generales.Options;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.IRepository
{
    public interface IEstadoTecnicoRepository
    {
        List<EstadoTecnico> FindAllEstadoTecnicos(EstadoTecniccoSearchOptions options);
        StatusResponse InsertEstadoTecnico(EstadoTecnico estadoTecnico);
        StatusResponse UpdateEstadoTecnico(EstadoTecnico estadoTecnico);
        StatusResponse DeleteEstadoTecnico(EstadoTecnico estadoTecnico);
        EstadoTecnico GetEstadoTecnicobyId(int estadoTecnicoId);
    }
}
