using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Geograficos.ClassMap
{
   public class ZonaUbicacionMap : ClassMap<ZonaUbicacion>
    {
        public ZonaUbicacionMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Active);
            
            Table("ZonaUbicacion");

        }
    }
}