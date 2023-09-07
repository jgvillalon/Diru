using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas.ClassMap
{
   public class DisposicionEdificacionMap : ClassMap<DisposicionEdificacionRU>
    {
        public DisposicionEdificacionMap()
        {
            Id(x => x.Id);
            Map(x => x.Abiertas);
            Map(x => x.AbiertasObservaciones);
            Map(x => x.AbiertasImagen);
            Map(x => x.SemiCompacta);
            Map(x => x.SemiCompactaObservaciones);
            Map(x => x.SemiCompactaImagen);
            Map(x => x.Compactas);
            Map(x => x.CompactasObservaciones);
            Map(x => x.CompactasImagen);

            References(x => x.InversionLote);

            Table("DisposicionEdificacionRU");
        }
    }
}