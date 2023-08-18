using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.ClassMap
{
    public class InversionMap : ClassMap<Inversion>
    {
        public InversionMap()
        {
            Id(x => x.Id);
            Map(x => x.NombreInversion);
            Map(x => x.NombreObra);
            Map(x => x.NoCalle);
            Map(x => x.Reparto);
            Map(x => x.Manzana);
            Map(x => x.ECalle);
            Map(x => x.Circunscripcion);
            Map(x => x.ConsejoPopular);
            Map(x => x.Equipos);
            Map(x => x.Otros);
            Map(x => x.ValorEstimado).Precision(18).Scale(2);
            Map(x => x.ValorEstimadoAprobado).Precision(18).Scale(2);
            Map(x => x.ConstruccionMontaje);
            References(x => x.Proyecto);
            References(x => x.Zona);
            References(x => x.Provincia);
            References(x => x.Municipio);

            Table("Inversion");

        }
    }
}