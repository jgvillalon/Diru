using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Geograficos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos
{
   public class Inversion
    {
        public virtual int Id { get; set; }
        public virtual string NombreInversion { get; set; }
        public virtual string NombreObra { get; set; }
        public virtual string NoCalle { get; set; }
        public virtual string ECalle { get; set; }
        public virtual string Reparto { get; set; }
        public virtual string ConsejoPopular { get; set; }
        public virtual ZonaUbicacion Zona { get; set; }
        public virtual string Manzana { get; set; }
        public virtual string Circunscripcion { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual decimal ValorEstimadoConstruccion { get; set; }
        public virtual decimal ValorEstimadoEquipos { get; set; }
        public virtual decimal ValorEstimadoOtros { get; set; }
        public virtual decimal ValorEstimadoAprobadoConstruccion { get; set; }
        public virtual decimal ValorEstimadoAprobadoEquipos { get; set; }
        public virtual decimal ValorEstimadoAprobadoOtros { get; set; }
        public virtual string ConstruccionMontaje { get; set; }
        public virtual string Equipos { get; set; }
        public virtual string Otros { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
