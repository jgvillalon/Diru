using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales
{
    public class Entidad
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Codigo { get; set; }
        public virtual bool Active { get; set; }
        public virtual Organismo Organismo { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
