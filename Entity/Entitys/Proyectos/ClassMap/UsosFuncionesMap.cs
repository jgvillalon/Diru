using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas.ClassMap
{
   public class UsosFuncionesMap : ClassMap<UsosFuncionesRU>
    {
        public UsosFuncionesMap()
        {
            Id(x => x.Id);
            Map(x => x.Residencial);
            Map(x => x.ResidencialObservacion);
            Map(x => x.ResidencialImagen);
            Map(x => x.EspaciosPublicoVerde);
            Map(x => x.EspaciosPublicoVerdeObservacion);
            Map(x => x.EspaciosPublicoVerdeImagen);
            Map(x => x.Alojamiento);
            Map(x => x.AlojamientoObservacion);
            Map(x => x.ImagenAlojamiento);
            Map(x => x.Administrativo);
            Map(x => x.AdministrativoObservacion);
            Map(x => x.ImagenAdministrativo);
            Map(x => x.Comercio);
            Map(x => x.ComercioObservacion);
            Map(x => x.ImagenComercio);
            Map(x => x.Gastronomia);
            Map(x => x.GastronomiaObservacion);
            Map(x => x.ImagenGastronomia);
            Map(x => x.ServiciosCiudad);
            Map(x => x.ServiciosCiudadObservacion);
            Map(x => x.ImagenServiciosCiudad);
            Map(x => x.ServiciosBasicos);
            Map(x => x.ServiciosBasicosObservacion);
            Map(x => x.ImagenServiciosBasicos);
            Map(x => x.AlmacenesTalleresPequeños);
            Map(x => x.AlmacenesTalleresPequeñosObservacion);
            Map(x => x.ImagenAlmacenesTalleresPequeños);

            Map(x => x.Comunales);
            Map(x => x.ComunalesObservacion);
            Map(x => x.ComunalesImagen);
            Map(x => x.AgriculturaUrbana);
            Map(x => x.AgriculturaUrbanaObservacion);
            Map(x => x.AgriculturaUrbanaImagen);
            Map(x => x.Especiales);
            Map(x => x.EspecialesObservacion);
            Map(x => x.ImagenEspeciales);
            Map(x => x.Produccion);
            Map(x => x.ProduccionObservacion);
            Map(x => x.ImagenProduccion);
            Map(x => x.Religioso);
            Map(x => x.ReligiosoObservacion);
            Map(x => x.ImagenReligioso);
            Map(x => x.Agropecuario);
            Map(x => x.AgropecuarioObservacion);
            Map(x => x.ImagenAgropecuario);
            Map(x => x.ParqueosLotesVacios);
            Map(x => x.ParqueosLotesVaciosObservacion);
            Map(x => x.ImagenParqueosLotesVacios);
            Map(x => x.ParqueosConstruidos);
            Map(x => x.ParqueosConstruidosObservacion);
            Map(x => x.ImagenParqueosConstruidos);

            References(x => x.InversionLote);

            Table("UsosFuncionesRU");
        }
    }
}