using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Seguridad.ClassMap
{
   public class LicenseMap : ClassMap<License>
    {
        public LicenseMap()
        {
            Id(x => x.Id);
            Map(x => x.Codigo);
            Map(x => x.Encrypt_Date);
            Map(x => x.Tipo);
            Table("License");

        }
    }
}
