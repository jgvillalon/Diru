using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Otros;
using Repository.Nomencladores.Otros.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Otros.IService
{
    public interface IAccionPrecioService
    {
        Response InsertAccionPrecio(AccionPrecio accionPrecio);
        Response UpdateAccionPrecio(AccionPrecio accionPrecio);
        Response DeleteAccionPrecio(int accionPrecioId);
        AccionPrecio GetAccionPreciobyId(int accionPrecioId);
        List<AccionPrecio> FindAllAccionPrecios(AccionPrecioSearchOptions options = null);
    }
}
