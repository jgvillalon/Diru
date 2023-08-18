using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos
{
   public enum EstadoProyecto
    {
        Iniciado = 0,
        EnProceso = 1,
        Diagnosticado = 2,
        EvaluandoCapacidad = 3,
        EvaluandoVulnerabilidad = 4,
        Cancelado = 6,
        Reiniciado = 5,
        Terminado = 7,
        EnRegeneracionUrbana = 8,

    }
}
