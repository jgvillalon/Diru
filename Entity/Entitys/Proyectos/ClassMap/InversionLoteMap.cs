using Entity.Entitys.Proyectos.InversionesLotes;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.ClassMap
{
    public class InversionLoteMap : ClassMap<InversionLote>
    {
        public InversionLoteMap()
        {
            Id(x => x.Id);

            Map(x => x.UrlEvaluaciones);
            Map(x => x.AreaLotes).Precision(18).Scale(2);
            Map(x => x.NoTerreno);
            Map(x => x.SuperficieHidrica).Precision(18).Scale(2);
            Map(x => x.SuperficieVerde).Precision(18).Scale(2);
            Map(x => x.ProfundidadManto).Precision(18).Scale(2);
            Map(x => x.TopografiaPendiente).Precision(18).Scale(2);
            Map(x => x.ValoresPaisajisticos);
            Map(x => x.CantidadHabitantes);
            Map(x => x.ViasTransportePublico);
            Map(x => x.CantidadPlantas);

            HasMany(x => x.Plantas)
            .Inverse()
            .Cascade.AllDeleteOrphan()
            .Fetch.Subselect();

            HasMany(x => x.Redes)
            .Inverse()
            .Cascade.AllDeleteOrphan()
            .Fetch.Subselect();


           // HasManyToMany(x => x.Redes)
           //.Table("InversionLoteRed")
           //.ParentKeyColumn("InversionLoteId")
           //.ChildKeyColumn("RedId")
           //.Inverse()
           //.Cascade.All();
            
            References(x => x.Proyecto);

            Table("InversionLote");

        }
    }
}