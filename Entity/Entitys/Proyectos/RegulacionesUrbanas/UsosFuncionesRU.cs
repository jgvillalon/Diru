using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas
{
    public class UsosFuncionesRU
    {
        public virtual int Id { get; set; }
        public virtual float Residencial { get; set; }
        public virtual string ResidencialObservacion { get; set; }
        public virtual string ResidencialImagen { get; set; }
        public virtual float EspaciosPublicoVerde { get; set; }
        public virtual string EspaciosPublicoVerdeObservacion { get; set; }
        public virtual string EspaciosPublicoVerdeImagen { get; set; }
        public virtual float Alojamiento { get; set; }
        public virtual string AlojamientoObservacion { get; set; }
        public virtual string ImagenAlojamiento { get; set; }
        public virtual float Administrativo { get; set; }
        public virtual string AdministrativoObservacion { get; set; }
        public virtual string ImagenAdministrativo { get; set; }
        public virtual float Comercio { get; set; }
        public virtual string ComercioObservacion { get; set; }
        public virtual string ImagenComercio { get; set; }
        public virtual float Gastronomia { get; set; }
        public virtual string GastronomiaObservacion { get; set; }
        public virtual string ImagenGastronomia { get; set; }
        public virtual float ServiciosCiudad { get; set; }
        public virtual string ServiciosCiudadObservacion { get; set; }
        public virtual string ImagenServiciosCiudad { get; set; }
        public virtual float ServiciosBasicos { get; set; }
        public virtual string ServiciosBasicosObservacion { get; set; }
        public virtual string ImagenServiciosBasicos { get; set; }
        public virtual float AlmacenesTalleresPequeños { get; set; }
        public virtual string AlmacenesTalleresPequeñosObservacion { get; set; }
        public virtual string ImagenAlmacenesTalleresPequeños { get; set; }
        public virtual float Comunales { get; set; }
        public virtual string ComunalesObservacion { get; set; }
        public virtual string ComunalesImagen { get; set; }
        public virtual float AgriculturaUrbana { get; set; }
        public virtual string AgriculturaUrbanaObservacion { get; set; }
        public virtual string AgriculturaUrbanaImagen { get; set; }
        public virtual float Especiales { get; set; }
        public virtual string EspecialesObservacion { get; set; }
        public virtual string ImagenEspeciales { get; set; }
        public virtual float Produccion { get; set; }
        public virtual string ProduccionObservacion { get; set; }
        public virtual string ImagenProduccion { get; set; }
        public virtual float Religioso { get; set; }
        public virtual string ReligiosoObservacion { get; set; }
        public virtual string ImagenReligioso { get; set; }
        public virtual float Agropecuario { get; set; }
        public virtual string AgropecuarioObservacion { get; set; }
        public virtual string ImagenAgropecuario { get; set; }
        public virtual float ParqueosLotesVacios { get; set; }
        public virtual string ParqueosLotesVaciosObservacion { get; set; }
        public virtual string ImagenParqueosLotesVacios { get; set; }
        public virtual float ParqueosConstruidos { get; set; }
        public virtual string ParqueosConstruidosObservacion { get; set; }
        public virtual string ImagenParqueosConstruidos { get; set; }
        public virtual InversionLote InversionLote { get; set; }
    }
}
