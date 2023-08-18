using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos
{
   public class Capacidad
    {
        public virtual int Id { get; set; }
        public virtual int Zona { get; set; }
        public virtual string AreaUrbanizada { get; set; }
        public virtual string UsoResidencial { get; set; }
        public virtual string UsoIndustrial { get; set; }
        public virtual string EvalUrbanizacion { get; set; }
        public virtual string ContSonora { get; set; }
        public virtual string EvalContSonora { get; set; }
        public virtual string Desplazamiento { get; set; }
        public virtual string EvalDeslizamiento { get; set; }
        public virtual string Inundaciones { get; set; }
        public virtual string EvalInundaciones { get; set; }
        public virtual string Incendios { get; set; }
        public virtual string EvalIncendios { get; set; }
        public virtual string ContAcuifera { get; set; }
        public virtual string EvalContAcuifera { get; set; }
        public virtual string EvalGeneral { get; set; }

        public virtual string SueloFertil { get; set; }
        public virtual string SueloCenagoso { get; set; }
        public virtual string SueloArido { get; set; }
        public virtual string EvaluacionSuelos { get; set; }
        public virtual string Visuales { get; set; }
        public virtual string EvaluacionVisuales { get; set; }
        public virtual string VegetacionCultivo { get; set; }
        public virtual string PocaVegetacion { get; set; }
        public virtual string Palmar { get; set; }
        public virtual string EvaluacionVegetacion { get; set; }
        public virtual string EcoDannado { get; set; }
        public virtual string EcoConservado { get; set; }
        public virtual string EvaluacionEcosistema { get; set; }
        public virtual string VaguadaNatural { get; set; }
        public virtual string EvaluacionVaguada { get; set; }
        public virtual string EvalGeneralVulnerabilidad { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
