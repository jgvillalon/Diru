using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas.ClassMap
{
   public class AlturaRUMap : ClassMap<AlturaRU>
    {
        public AlturaRUMap()
        {
            Id(x => x.Id);
            Map(x => x.NoMinNiveles);
            Map(x => x.ObservacionNoMNiinveles);
            Map(x => x.UrlNoMinNiveles);
            Map(x => x.NoMAxNiveles);
            Map(x => x.ObservacionNoMAxNiveles);
            Map(x => x.UrlNoMAxNiveles);
            Map(x => x.PuntalMinPB);
            Map(x => x.ObservacionPuntalMinPB);
            Map(x => x.UrlPuntalMinPB);
            Map(x => x.PuntalMinGeneral);
            Map(x => x.ObservacionPuntalMinGeneral);
            Map(x => x.UrlPuntalMinGeneral);

            References(x => x.InversionLote);

            Table("AlturaRU");
        }
    }
}