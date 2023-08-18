﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales
{
   public class Municipio
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool Active { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
