using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas.ClassMap
{
   public class EstructuraMap : ClassMap<Estructuras>
    {
        public EstructuraMap()
        {
            Id(x => x.Id);
            Map(x => x.NoEstructura);
            Map(x => x.MaximaOcupacion);
            Map(x => x.MaximaOcupacionImagen);
            Map(x => x.MaximaOcupacionObservaciones);
            Map(x => x.MinimaOcupacion);
            Map(x => x.MinimaOcupacionImagen);
            Map(x => x.MinimaOcupacionObservaciones);

            References(x => x.InversionLote);

            Table("Estructura");
        }
    }
}