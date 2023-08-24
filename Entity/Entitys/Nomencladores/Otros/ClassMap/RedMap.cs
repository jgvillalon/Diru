using Entity.Entitys.Proyectos.InversionesLotes;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Otros.ClassMap
{
    public class RedMap : ClassMap<Red>
    {
        public RedMap()
        {
            Id(x => x.Id);

            Map(x => x.Nombre);

            HasManyToMany(x => x.InversionLotes)
           .Table("InversionLoteRed")
           .ParentKeyColumn("RedId")
           .ChildKeyColumn("InversionLoteId")
           .Inverse();

            //References(x => x.InversionLote).Not.Nullable().Cascade.None();

            Table("Red");

        }
    }
}