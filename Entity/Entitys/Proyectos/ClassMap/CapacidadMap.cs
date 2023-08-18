using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.ClassMap
{
   public class CapacidadMap : ClassMap<Capacidad>
    {
        public CapacidadMap()
        {
            Id(x => x.Id);
            Map(x => x.Zona);
            Map(x => x.AreaUrbanizada);
            Map(x => x.ContAcuifera);
            Map(x => x.ContSonora);
            Map(x => x.Desplazamiento);
            Map(x => x.EvalContAcuifera);
            Map(x => x.EvalGeneral);
            Map(x => x.EvalContSonora);
            Map(x => x.EvalIncendios);
            Map(x => x.EvalInundaciones);
            Map(x => x.EvalUrbanizacion);
            Map(x => x.EvalDeslizamiento);
            Map(x => x.Incendios);
            Map(x => x.Inundaciones);
            Map(x => x.UsoIndustrial);
            Map(x => x.UsoResidencial);

            Map(x => x.SueloFertil);
            Map(x => x.SueloCenagoso);
            Map(x => x.SueloArido);
            Map(x => x.EvaluacionSuelos);
            Map(x => x.Visuales);
            Map(x => x.EvaluacionVisuales);
            Map(x => x.VegetacionCultivo);
            Map(x => x.PocaVegetacion);
            Map(x => x.Palmar);
            Map(x => x.EvaluacionVegetacion);
            Map(x => x.EcoDannado);
            Map(x => x.EcoConservado);
            Map(x => x.EvaluacionEcosistema);
            Map(x => x.VaguadaNatural);
            Map(x => x.EvaluacionVaguada);
            Map(x => x.EvalGeneralVulnerabilidad);

           References(x => x.Proyecto);
          
         

            Table("Capacidad");

        }
    }
}