using Entity.Entitys.Nomencladores.Generales;
using Repository.Common;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Nomencladores.Generales.IRepository
{
   public interface IPaisRepository
    {
        List<Pais> FindAllPaises(PaisSearchOptions options);
        StatusResponse InsertPais(Pais pais);
        StatusResponse UpdatePais(Pais pais);
        StatusResponse DeletePais(Pais pais);
        Pais GetPaisbyId(int paisId);
    }
}
