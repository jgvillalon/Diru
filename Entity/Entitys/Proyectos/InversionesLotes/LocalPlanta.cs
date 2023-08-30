using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Otros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.InversionesLotes
{
    public class LocalPlanta
    {
        public virtual int Id { get; set; }
        public virtual string Local { get; set; }
        public virtual Planta Planta { get; set; }
        public virtual decimal AreaOcupada { get; set; }
        public virtual bool Nuevo { get; set; }
        public virtual ElementoEstado Estado { get; set; }
        public virtual AccionLocal Accion { get; set; }
        public virtual decimal AccionPrecio { get; set; }
        public virtual string NoLocal { get; set; }

    }
}
