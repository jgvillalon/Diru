using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales.ClassMap
{
   public class OrganismoMap : ClassMap<Organismo>
    {
        public OrganismoMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Active);
            
            Table("Organismo");

        }
    }
}