using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales.ClassMap
{
   public class MunicipioMap : ClassMap<Municipio>
    {
        public MunicipioMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Active);
            References(x => x.Provincia).Cascade.All();
            Table("Municipio");

        }
    }
}