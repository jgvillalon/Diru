using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seguridad.Options
{
   public  class UserSearchOptions
    {
        public string Username { get; set; }
        public string Nombre { get; set; }
        public bool? Active { get; set; }
    }
}
