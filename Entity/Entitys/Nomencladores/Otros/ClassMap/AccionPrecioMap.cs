using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Otros.ClassMap
{
    internal class AccionPrecioMap : ClassMap<AccionPrecio>
    {
        public AccionPrecioMap()
        {
            Id(x => x.Id);
            Map(x => x.Accion);
            Map(x => x.PrecioBueno).Precision(18).Scale(2);
            Map(x => x.PrecioMalo).Precision(18).Scale(2);
            Map(x => x.PrecioRegular).Precision(18).Scale(2);
            Map(x => x.Active);

            Table("AccionPrecio");

        }
    }
}