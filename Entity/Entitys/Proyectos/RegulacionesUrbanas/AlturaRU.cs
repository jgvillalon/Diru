using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas
{
    public class AlturaRU
    {
        public virtual int Id { get; set; }
        public virtual float NoMAxNiveles { get; set; }
        public virtual string ObservacionNoMAxNiveles { get; set; }
        public virtual string UrlNoMAxNiveles { get; set; }
        public virtual float NoMinNiveles { get; set; }
        public virtual string ObservacionNoMNiinveles { get; set; }
        public virtual string UrlNoMinNiveles { get; set; }
        public virtual float PuntalMinPB { get; set; }
        public virtual string ObservacionPuntalMinPB { get; set; }
        public virtual string UrlPuntalMinPB { get; set; }
        public virtual float PuntalMinGeneral { get; set; }
        public virtual string ObservacionPuntalMinGeneral { get; set; }
        public virtual string UrlPuntalMinGeneral { get; set; }
        public virtual InversionLote InversionLote { get; set; }
    }
}
