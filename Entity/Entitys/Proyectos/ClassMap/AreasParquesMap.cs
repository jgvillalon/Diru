using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas.ClassMap
{
   public class AreasParquesMap : ClassMap<AreasParquesRU>
    {
        public AreasParquesMap()
        {
            Id(x => x.Id);
            Map(x => x.ParquesUrbanos);
            Map(x => x.ParquesUrbanosObservacion);
            Map(x => x.ParquesUrbanosImagen);
            Map(x => x.Microparques);
            Map(x => x.MicroparquesObservacion);
            Map(x => x.MicroparquesImagen);
            Map(x => x.Plazas);
            Map(x => x.PlazasObservacion);
            Map(x => x.ImagenPlazas);
            Map(x => x.ArboladosAvenidas);
            Map(x => x.ArboladosAvenidasObservacion);
            Map(x => x.ImagenArboladosAvenidas);
            Map(x => x.ParquesRecreativos);
            Map(x => x.ParquesRecreativosObservacion);
            Map(x => x.ImagenParquesRecreativos);
            Map(x => x.ParquesInfantiles);
            Map(x => x.ParquesInfantilesObservacion);
            Map(x => x.ImagenParquesInfantiles);
            Map(x => x.EspaciosAbiertosNaturales);
            Map(x => x.EspaciosAbiertosNaturalesObservacion);
            Map(x => x.ImagenEspaciosAbiertosNaturales);

            References(x => x.InversionLote);

            Table("AreasParquesRU");
        }
    }
}