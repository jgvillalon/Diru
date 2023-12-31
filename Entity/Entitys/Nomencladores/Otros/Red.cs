﻿using Entity.Entitys.Nomencladores.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.InversionesLotes
{
    public class Red
    {
        public Red()
        {
            InversionLotes = new List<InversionLote>();
        }
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual IList<InversionLote> InversionLotes { get; set; }
        //public virtual InversionLote InversionLote { get; set; }
    }
}
