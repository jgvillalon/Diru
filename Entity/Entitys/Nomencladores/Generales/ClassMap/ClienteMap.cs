using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Nomencladores.Generales.ClassMap
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.Id);
            Map(x => x.Responsable);
            Map(x => x.Active);
            Map(x => x.NaturalJuridica);
            Map(x => x.Telefono);
            Map(x => x.Correo);
            Map(x => x.CI);
            Map(x => x.Codigo);
            Map(x => x.Direccion);
            References(x => x.Entidad);
            References(x => x.Municipio);

            Table("Cliente");

        }
    }
}
