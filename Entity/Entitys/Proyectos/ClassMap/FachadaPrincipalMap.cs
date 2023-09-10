using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas.ClassMap
{
   public class FachadaPrincipalMap : ClassMap<FachadaPrincipalRU>
    {
        public FachadaPrincipalMap()
        {
            Id(x => x.Id);
            Map(x => x.Portales);
            Map(x => x.PortalesObservacion);
            Map(x => x.PortalesImagen);
            Map(x => x.Cercado);
            Map(x => x.CercadoObservacion);
            Map(x => x.CercadoImagen);
            Map(x => x.PortalPublico);
            Map(x => x.PortalPublicoObservacion);
            Map(x => x.ImagenPortalPublico);
            Map(x => x.VistasLuces);
            Map(x => x.VistasLucesObservacion);
            Map(x => x.ImagenVistasLuces);
            Map(x => x.Salientes);
            Map(x => x.SalientesObservacion);
            Map(x => x.ImagenSalientes);
            Map(x => x.SotanosSemisotanos);
            Map(x => x.SotanosSemisotanosObservacion);
            Map(x => x.ImagenSotanosSemisotanos);
            Map(x => x.Medianerias);
            Map(x => x.MedianeriasObservacion);
            Map(x => x.ImagenMedianerias);
            Map(x => x.MarquesinasToldos);
            Map(x => x.MarquesinasToldosObservacion);
            Map(x => x.ImagenMarquesinasToldos);
            Map(x => x.BalconesLoggiasTerrazas);
            Map(x => x.BalconesLoggiasTerrazasObservacion);
            Map(x => x.ImagenBalconesLoggiasTerrazas);

            References(x => x.InversionLote);

            Table("FachadaPrincipalRU");
        }
    }
}