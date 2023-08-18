using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Seguridad
{
    public class AppVersion
    {
        public virtual int Id { get; set; }
        public virtual string Version { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual string UpgradeNotes { get; set; }
    }
}
