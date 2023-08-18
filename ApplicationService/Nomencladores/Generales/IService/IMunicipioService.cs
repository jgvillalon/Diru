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
    public interface IMunicipioService
    {
        Response InsertMunicipio(Municipio municipio);
        Response UpdateMunicipio(Municipio municipio);
        Response DeleteMunicipio(int municipioId);
        Municipio GetMunicipiobyId(int municipioId);
        List<Municipio> FindAllMunicipios(MunicipioSearchOptions options = null);
    }
}
