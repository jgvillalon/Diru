using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Seguridad.ClassMap
{
   public class UserRoleMap : ClassMap<UserRole>
    {
        public UserRoleMap()
        {
            Id(x => x.Id);
            Map(x => x.Role);
            References(x => x.User).Unique().Cascade.All();
            Table("UserRole");

        }
    }
}
