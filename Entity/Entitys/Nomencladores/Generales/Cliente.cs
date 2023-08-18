using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string Responsable { get; set; }
        public virtual bool NaturalJuridica { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string CI { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Correo { get; set; }
        public virtual Entidad Entidad { get; set; }
        public virtual Organismo Organismo { get; set; }
        public virtual string Reparto { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual bool Active { get; set; }

        public virtual string NombreCompleto => $"{Entidad?.Nombre ?? "Persona natural"} - {Responsable}";
    }
}
