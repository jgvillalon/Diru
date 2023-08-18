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
    public interface IProvinciaService
    {
        Response InsertProvincia(Provincia provincia);
        Response UpdateProvincia(Provincia provincia);
        Response DeleteProvincia(int provinciaId);
        Provincia GetProvinciabyId(int provinciaId);
        List<Provincia> FindAllProvincias(ProvinciaSearchOptions options = null);
    }
}
