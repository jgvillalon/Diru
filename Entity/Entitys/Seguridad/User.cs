using Entity.Entitys.Proyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys
{
   public class User
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellidos { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Password { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual Proyecto LastProject { get; set; }
        public virtual string LastView { get; set; }
        public virtual bool Active { get; set; }
    }
}
