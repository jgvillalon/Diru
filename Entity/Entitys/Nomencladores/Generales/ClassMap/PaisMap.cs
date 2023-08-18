using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales.ClassMap
{
   public class PaisMap : ClassMap<Pais>
    {
        public PaisMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Active);
            Table("Pais");

        }
    }
}