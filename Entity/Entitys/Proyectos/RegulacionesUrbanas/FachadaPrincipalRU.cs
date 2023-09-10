using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas
{
    public class FachadaPrincipalRU
    {
        public virtual int Id { get; set; }
        public virtual float Portales { get; set; }
        public virtual string PortalesObservacion { get; set; }
        public virtual string PortalesImagen { get; set; }
        public virtual float Cercado { get; set; }
        public virtual string CercadoObservacion { get; set; }
        public virtual string CercadoImagen { get; set; }
        public virtual float PortalPublico { get; set; }
        public virtual string PortalPublicoObservacion { get; set; }
        public virtual string ImagenPortalPublico { get; set; }
        public virtual float VistasLuces { get; set; }
        public virtual string VistasLucesObservacion { get; set; }
        public virtual string ImagenVistasLuces { get; set; }
        public virtual float Salientes { get; set; }
        public virtual string SalientesObservacion { get; set; }
        public virtual string ImagenSalientes { get; set; }
        public virtual float SotanosSemisotanos { get; set; }
        public virtual string SotanosSemisotanosObservacion { get; set; }
        public virtual string ImagenSotanosSemisotanos { get; set; }
        public virtual float Medianerias { get; set; }
        public virtual string MedianeriasObservacion { get; set; }
        public virtual string ImagenMedianerias { get; set; }
        public virtual float MarquesinasToldos { get; set; }
        public virtual string MarquesinasToldosObservacion { get; set; }
        public virtual string ImagenMarquesinasToldos { get; set; }
        public virtual float BalconesLoggiasTerrazas { get; set; }
        public virtual string BalconesLoggiasTerrazasObservacion { get; set; }
        public virtual string ImagenBalconesLoggiasTerrazas { get; set; }
        public virtual InversionLote InversionLote { get; set; }
    }
}
