using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales.ClassMap
{
   public class EntidadMap : ClassMap<Entidad>
    {
        public EntidadMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Active);
            Map(x => x.Codigo).Unique();
            References(x => x.Organismo).Cascade.All();
            References(x => x.Municipio).Cascade.All();
            Table("Entidad");

        }
    }
}