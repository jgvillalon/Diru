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
    public interface IMunicipioRepository
    {
        List<Municipio> FindAllMunicipios(MunicipioSearchOptions options);
        StatusResponse InsertMunicipio(Municipio municipio);
        StatusResponse UpdateMunicipio(Municipio municipio);
        StatusResponse DeleteMunicipio(Municipio municipio);
        Municipio GetMunicipiobyId(int municipioId);
    }
}
