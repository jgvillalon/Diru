using Entity.Entitys.Nomencladores.Otros;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.ClassMap
{
    public class EstadoTecnicoProyectoMap : ClassMap<EstadoTecnicoProyecto>
    {
        public EstadoTecnicoProyectoMap()
        {
            Id(x => x.Id);
            Map(x => x.Clasificacion);
            Map(x => x.Valor);
          
            References(x => x.Proyecto);
            References(x => x.EstadoTecnico);
            
            Table("EstadoTecnicoProyecto");

        }
    }
}
