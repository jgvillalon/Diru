using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Otros.ClassMap
{
    public class EstadoTecnicoMap : ClassMap<EstadoTecnico>
    {
        public EstadoTecnicoMap()
        {
            Id(x => x.Id);
            Map(x => x.Elementos);
            Map(x => x.MinBueno);
            Map(x => x.MaxBueno);
            Map(x => x.MinMalo);
            Map(x => x.MaxMalo);
            Map(x => x.MinRegular);
            Map(x => x.MaxRegular);
            Map(x => x.Active);

            Table("EstadoTecnico");

        }
    }
}
