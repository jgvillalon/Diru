using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Seguridad
{
   public class License
    {
        public virtual int Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Encrypt_Date { get; set; }
        public virtual int Tipo { get; set; }
    }
}
