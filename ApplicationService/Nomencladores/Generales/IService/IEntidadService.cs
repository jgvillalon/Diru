using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Generales.IService
{
    public interface IEntidadService
    {
        Response InsertEntidad(Entidad entidad);
        Response UpdateEntidad(Entidad entidad);
        Response DeleteEntidad(int entidadId);
        Entidad GetEntidadbyId(int entidadId);
        List<Entidad> FindAllEntidades(EntidadSearchOptions options = null);
    }
}
