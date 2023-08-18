using Entity.Entitys.Nomencladores.Generales;
using Repository.Common;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Generales.IRepository
{
   public interface IEntidadRepository
    {
        List<Entidad> FindAllEntidades(EntidadSearchOptions options);
        StatusResponse InsertEntidad(Entidad entidad);
        StatusResponse UpdateEntidad(Entidad entidad);
        StatusResponse DeleteEntidad(Entidad entidad);
        Entidad GetEntidadbyId(int entidadId);
    }
}
