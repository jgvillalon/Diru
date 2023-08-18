using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Geograficos.ClassMap
{
   public class UbicacionGeograficaMap : ClassMap<UbicacionGeografica>
    {
        public UbicacionGeograficaMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Active);

            Table("UbicacionGeografica");

        }
    }
}