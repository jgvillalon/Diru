using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Otros
{
    public class AccionPrecio
    {
        public virtual int Id { get; set; }
        public virtual AccionLocal Accion { get; set; }
        public virtual decimal PrecioBueno { get; set; }
        public virtual decimal PrecioRegular { get; set; }
        public virtual decimal PrecioMalo { get; set; }
        public virtual bool Active { get; set; }
      
    }
}
