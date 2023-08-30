using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas
{
    public class Estructuras
    {
        public virtual int Id { get; set; }
        public virtual string NoEstructura { get; set; }
        public virtual string MaximaOcupacion { get; set; }
        public virtual string MaximaOcupacionImagen { get; set; }
        public virtual string MaximaOcupacionObservaciones { get; set; }
        public virtual string MinimaOcupacion { get; set; }
        public virtual string MinimaOcupacionImagen { get; set; }
        public virtual string MinimaOcupacionObservaciones { get; set; }
        public virtual InversionLote InversionLote { get; set; }
    }
}
