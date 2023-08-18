using Entity.Entitys.Nomencladores.Generales;
using Entity.Entitys.Nomencladores.Geograficos;
using Entity.Entitys.Nomencladores.Otros;
using Entity.Entitys.Proyectos.InversionesLotes;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos
{
   public class Proyecto
    {
        public Proyecto() {
            EstadoTecnicoElementos = new List<EstadoTecnicoProyecto>();
        }
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual TipoProyecto Tipo { get; set; }
        public virtual decimal AreaOcupada { get; set; }
        public virtual decimal SuperficieTotal { get; set; }
        public virtual EstadoProyecto Estado { get; set; }
        public virtual ZonaUbicacion ZonaUbicacion { get; set; }
        public virtual UbicacionGeografica UbicacionGeografica { get; set; }
        public virtual Inversion Inversion { get; set; }
        public virtual InversionLote InversionLotes { get; set; }
       
        public virtual string UrlImage { get; set; }
        public virtual string LastView { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual DateTime CreateOn { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool Current { get; set; }

        public virtual IList<EstadoTecnicoProyecto> EstadoTecnicoElementos { get; set; }

        public virtual int PuntuacionTotalEstadoTecnico()
        {

            return EstadoTecnicoElementos.Sum(e => e.Valor);
        }

        public virtual ElementoEstado ClasificacionEstadoTecnico()
        {

            int buena = EstadoTecnicoElementos.Count(e => e.Clasificacion == ElementoEstado.Bueno);
            int mala = EstadoTecnicoElementos.Count(e => e.Clasificacion == ElementoEstado.Malo);
            int regular = EstadoTecnicoElementos.Count(e => e.Clasificacion == ElementoEstado.Regular);

            //  int max = Math.Max(buena, Math.Max(mala, regular));
            if (buena > mala && buena > regular)
            {
                return ElementoEstado.Bueno;
            }
            else if (mala > buena && mala > regular)
            {
                return ElementoEstado.Malo;
            }
            else
            {
                return ElementoEstado.Regular;
            }

        }

    }
}
