using ApplicationService.Common;
using Entity.Entitys.Proyectos;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Proyectos.IService
{
   public interface ICapacidadService
    {
        Response InsertCapacidad(Capacidad capacidad);
        Response UpdateCapacidad(Capacidad capacidad);
        Response DeleteCapacidad(int capacidadId);
        Capacidad GetCapacidadbyId(int capacidadId);
        List<Capacidad> FindAllCapacidads(CapacidadSearchOptions options = null);
    }
}
