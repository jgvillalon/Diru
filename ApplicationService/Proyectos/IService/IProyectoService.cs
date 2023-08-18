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
   public interface IProyectoService
    {
        Response InsertProyecto(Proyecto proyecto);
        Response UpdateProyecto(Proyecto proyecto);
        Response DeleteProyecto(int proyectoId);
        Proyecto GetProyectobyId(int proyectoId);
        List<Proyecto> FindAllProyectos(ProyectoSearchOptions options = null);
    }
}
