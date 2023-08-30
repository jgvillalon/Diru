using Entity.Entitys.Proyectos.InversionesLotes;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.ClassMap
{
    public class PlantaMap : ClassMap<Planta>
    {
        public PlantaMap()
        {
            Id(x => x.Id);
            Map(x => x.Descripcion);
            Map(x => x.Area).Precision(18).Scale(2);
            Map(x => x.AreaNueva).Precision(18).Scale(2);
            Map(x => x.Nuevo);
           
            HasMany(x => x.Locales)
           .Inverse()
           .Cascade.AllDeleteOrphan()
           .Fetch.Subselect();

            References(x => x.InversionLote).Not.Nullable().Cascade.None();

            Table("Planta");

        }
    }
}