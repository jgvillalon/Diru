using Entity.Entitys.Proyectos;
using Repository.Common;
using Repository.Proyectos.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Proyectos.IRepository
{
   public interface ICapacidadRepository
    {
        List<Capacidad> FindAllCapacidads(CapacidadSearchOptions options);
        StatusResponse InsertCapacidad(Capacidad capacidad);
        StatusResponse UpdateCapacidad(Capacidad capacidad);
        StatusResponse DeleteCapacidad(Capacidad capacidad);
        Capacidad GetCapacidadbyId(int capacidadId);
    }
}
