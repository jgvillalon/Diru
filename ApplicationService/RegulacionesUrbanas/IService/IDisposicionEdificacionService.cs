using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Proyectos.InversionesLotes;
using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using Repository.InversionesLotes.Options;
using Repository.Nomencladores.Generales.Options;
using Repository.RegulacionesUrbanas.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.RegulacionesUrbanas.IService
{
    public interface IDisposicionEdificacionService
    {
        Response InsertDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion);
        Response UpdateDisposicionEdificacion(DisposicionEdificacionRU DisposicionEdificacion);
        Response DeleteDisposicionEdificacion(int DisposicionEdificacionId);
        DisposicionEdificacionRU GetDisposicionEdificacionbyId(int DisposicionEdificacionId);
        List<DisposicionEdificacionRU> FindAllDisposicionEdificacion(DisposicionEdificacionSearchOptions options = null);
    }
}
