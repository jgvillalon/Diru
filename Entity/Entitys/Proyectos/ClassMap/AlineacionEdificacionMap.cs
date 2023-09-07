using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas.ClassMap
{
   public class AlineacionEdificacionMap : ClassMap<AlineacionEdificacionRU>
    {
        public AlineacionEdificacionMap()
        {
            Id(x => x.Id);
            Map(x => x.Patio);
            Map(x => x.PatioObservacion);
            Map(x => x.PatioImagen);
            Map(x => x.FranjaJardin);
            Map(x => x.FranjaJardinObservacion);
            Map(x => x.FranjaJardinImagen);
            Map(x => x.Acera);
            Map(x => x.AceraObservacion);
            Map(x => x.ImagenAcera);
            Map(x => x.PortalMedio);
            Map(x => x.PortalMedioObservacion);
            Map(x => x.ImagenPortalMedio);
            Map(x => x.PortalCorrido);
            Map(x => x.PortalCorridoObservacion);
            Map(x => x.ImagenPortalCorrido);
            Map(x => x.PasilloLateral);
            Map(x => x.PasilloLateralObservacion);
            Map(x => x.ImagenPasilloLateral);
            Map(x => x.PasilloFondo);
            Map(x => x.PasilloFondoObservacion);
            Map(x => x.ImagenPasilloFondo);
            Map(x => x.Rectangulo);
            Map(x => x.RectanguloObservacion);
            Map(x => x.ImagenRectangulo);
            Map(x => x.PatioInterior);
            Map(x => x.PatioInteriorObservacion);
            Map(x => x.ImagenPatioInterior);
            Map(x => x.Cercado);
            Map(x => x.CercadoObservacion);
            Map(x => x.ImagenCercado);

            References(x => x.InversionLote);

            Table("AlineacionEdificacionRU");
        }
    }
}