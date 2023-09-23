using Entity.Entitys.Proyectos.InversionesLotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.RegulacionesUrbanas
{
    public class AreasParquesRU
    {
        public virtual int Id { get; set; }
        public virtual float ParquesUrbanos { get; set; }
        public virtual string ParquesUrbanosObservacion { get; set; }
        public virtual string ParquesUrbanosImagen { get; set; }
        public virtual float Microparques { get; set; }
        public virtual string MicroparquesObservacion { get; set; }
        public virtual string MicroparquesImagen { get; set; }
        public virtual float Plazas { get; set; }
        public virtual string PlazasObservacion { get; set; }
        public virtual string ImagenPlazas { get; set; }
        public virtual float ArboladosAvenidas { get; set; }
        public virtual string ArboladosAvenidasObservacion { get; set; }
        public virtual string ImagenArboladosAvenidas { get; set; }
        public virtual float ParquesRecreativos { get; set; }
        public virtual string ParquesRecreativosObservacion { get; set; }
        public virtual string ImagenParquesRecreativos { get; set; }
        public virtual float ParquesInfantiles { get; set; }
        public virtual string ParquesInfantilesObservacion { get; set; }
        public virtual string ImagenParquesInfantiles { get; set; }
        public virtual float EspaciosAbiertosNaturales { get; set; }
        public virtual string EspaciosAbiertosNaturalesObservacion { get; set; }
        public virtual string ImagenEspaciosAbiertosNaturales { get; set; }
        public virtual InversionLote InversionLote { get; set; }
    }
}
