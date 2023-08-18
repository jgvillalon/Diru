using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys
{
   public class UserRole
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

    }
}
