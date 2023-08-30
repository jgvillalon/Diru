using Entity.Entitys.Nomencladores.Otros;
using Repository.Common;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Otros.IRepository
{
    public interface IAccionPrecioRepository
    {
        List<AccionPrecio> FindAllAccionPrecios(AccionPrecioSearchOptions options);
        StatusResponse InsertAccionPrecio(AccionPrecio estadoTecnico);
        StatusResponse UpdateAccionPrecio(AccionPrecio estadoTecnico);
        StatusResponse DeleteAccionPrecio(AccionPrecio estadoTecnico);
        AccionPrecio GetAccionPreciobyId(int estadoTecnicoId);
    }
}
