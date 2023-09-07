using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas
{
    public class DisposicionEdificacionRU
    {
        public virtual int Id { get; set; }
        public virtual float Abiertas { get; set; }
        public virtual string AbiertasImagen { get; set; }
        public virtual string AbiertasObservaciones { get; set; }
        public virtual float Compactas { get; set; }
        public virtual string CompactasImagen { get; set; }
        public virtual string CompactasObservaciones { get; set; }
        public virtual float SemiCompacta { get; set; }
        public virtual string SemiCompactaImagen { get; set; }
        public virtual string SemiCompactaObservaciones { get; set; }
        public virtual InversionLote InversionLote { get; set; }
    }
}
