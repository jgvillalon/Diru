using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas
{
    public class AlineacionEdificacionRU
    {
        public virtual int Id { get; set; }
        public virtual float Patio { get; set; }
        public virtual string PatioObservacion { get; set; }
        public virtual string PatioImagen { get; set; }
        public virtual float FranjaJardin { get; set; }
        public virtual string FranjaJardinObservacion { get; set; }
        public virtual string FranjaJardinImagen { get; set; }
        public virtual float Acera { get; set; }
        public virtual string AceraObservacion { get; set; }
        public virtual string ImagenAcera { get; set; }
        public virtual float PortalMedio { get; set; }
        public virtual string PortalMedioObservacion { get; set; }
        public virtual string ImagenPortalMedio { get; set; }
        public virtual float PortalCorrido { get; set; }
        public virtual string PortalCorridoObservacion { get; set; }
        public virtual string ImagenPortalCorrido { get; set; }
        public virtual float PasilloLateral { get; set; }
        public virtual string PasilloLateralObservacion { get; set; }
        public virtual string ImagenPasilloLateral { get; set; }
        public virtual float PasilloFondo { get; set; }
        public virtual string PasilloFondoObservacion { get; set; }
        public virtual string ImagenPasilloFondo { get; set; }
        public virtual float Rectangulo { get; set; }
        public virtual string RectanguloObservacion { get; set; }
        public virtual string ImagenRectangulo { get; set; }
        public virtual float PatioInterior { get; set; }
        public virtual string PatioInteriorObservacion { get; set; }
        public virtual string ImagenPatioInterior { get; set; }
        public virtual float Cercado { get; set; }
        public virtual string CercadoObservacion { get; set; }
        public virtual string ImagenCercado { get; set; }
        public virtual InversionLote InversionLote { get; set; }
    }
}
