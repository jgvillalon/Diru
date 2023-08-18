using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales.ClassMap
{
   public class ProvinciaMap : ClassMap<Provincia>
    {
        public ProvinciaMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Active);
            References(x => x.Pais).Cascade.All();
            Table("Provincia");

        }
    }
}