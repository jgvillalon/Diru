using Entity.Entitys.Nomencladores.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos
{
    public class EstadoTecnicoProyecto
    {
           public virtual int Id { get; set; }
           public virtual Proyecto Proyecto { get; set; }
           public virtual EstadoTecnico EstadoTecnico { get; set; }
           public virtual ElementoEstado Clasificacion { get; set; }
           public virtual int Valor { get; set; }
    }
}
