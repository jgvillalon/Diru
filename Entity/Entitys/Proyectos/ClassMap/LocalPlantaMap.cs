﻿using Entity.Entitys.Proyectos.InversionesLotes;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entitys.Proyectos.ClassMap
{
    public class LocalPlantaMap : ClassMap<LocalPlanta>
    {
        public LocalPlantaMap()
        {
            Id(x => x.Id);
            Map(x => x.Local);
            Map(x => x.AreaOcupada).Precision(18).Scale(2);
            Map(x => x.Nuevo);
            Map(x => x.Estado);
            Map(x => x.Accion);
            Map(x => x.AccionPrecio).Precision(18).Scale(2);
            References(x => x.Planta).Not.Nullable().Cascade.None();
            Map(x => x.NoLocal);
            Map(x => x.Libre);
            //References(x => x.Local).Not.Nullable().Cascade.SaveUpdate();

            Table("LocalPlanta");

        }
    }
}