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
    public interface IProyectoRepository
    {
        List<Proyecto> FindAllProyectos(ProyectoSearchOptions options);
        StatusResponse InsertProyecto(Proyecto proyecto);
        StatusResponse UpdateProyecto(Proyecto proyecto);
        StatusResponse DeleteProyecto(Proyecto proyecto);
        Proyecto GetProyectobyId(int proyectoId);
    }
}
