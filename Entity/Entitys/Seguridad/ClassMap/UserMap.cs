using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.ClassMap
{
   public class UserMap : ClassMap<User>
    {
        public UserMap() {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.Apellidos);
            Map(x => x.Telefono);
            Map(x => x.Correo);
            Map(x => x.LastView);
            Map(x => x.Username).Unique();
            Map(x => x.Password);
            Map(x => x.Active);
            HasOne(x => x.UserRole).Cascade.All().PropertyRef("User");
            References(x => x.LastProject); 
            Table("Users");

        }
    }
}
