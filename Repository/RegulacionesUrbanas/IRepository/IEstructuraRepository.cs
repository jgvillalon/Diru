using Entity.Entitys.Proyectos.RegulacionesUrbanas;
using Repository.Common;
using Repository.RegulacionesUrbanas.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RegulacionesUrbanas.IRepository
{
   public interface IEstructuraRepository
    {
        List<Estructuras> FindAllEstructuras(EstructuraSearchOptions options);
        StatusResponse InsertEstructura(Estructuras estructura);
        StatusResponse UpdateEstructura(Estructuras estructura);
        StatusResponse DeleteEstructura(Estructuras estructura);
        Estructuras GetEstructurabyId(int estructuraId);
    }
}
