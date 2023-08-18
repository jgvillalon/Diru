using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Otros.ClassMap
{
    public class MetrosMap : ClassMap<Metros>
    {
        public MetrosMap()
        {
            Id(x => x.Id);
            Map(x => x.Cantidad);
            Map(x => x.Active);

            Table("Metros");

        }
    }
}
