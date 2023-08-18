using ApplicationService.Common;
using Entity.Entitys.Nomencladores.Generales;
using Repository.Nomencladores.Generales.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Nomencladores.Generales.IService
{
    public interface IPaisService
    {
        Response InsertPais(Pais pais);
        Response UpdatePais(Pais pais);
        Response DeletePais(int paisId);
        Pais GetPaisbyId(int paisId);
        List<Pais> FindAllPaises(PaisSearchOptions options = null);
    }
}
