using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.ClassMap
{
    public class ProyectoMap : ClassMap<Proyecto>
    {
        public ProyectoMap()
        {
            Id(x => x.Id);
            Map(x => x.Nombre);
            Map(x => x.AreaOcupada).Precision(18).Scale(2);
            Map(x => x.LastView);
            Map(x => x.Estado);
            Map(x => x.SuperficieTotal).Precision(18).Scale(2);
            Map(x => x.Tipo);
            Map(x => x.UrlImage);
            Map(x => x.Active);
            Map(x => x.CreateOn);
            References(x => x.CreatedBy);
            References(x => x.Cliente);
            References(x => x.UbicacionGeografica);
            References(x => x.ZonaUbicacion);
            References(x => x.Inversion);
            References(x => x.InversionLotes)
            .Cascade.All();
           
            HasMany(x => x.EstadoTecnicoElementos)
            .Inverse()
            .Cascade.AllDeleteOrphan()
            .Fetch.Join();


            Table("Proyecto");

        }
    }
}