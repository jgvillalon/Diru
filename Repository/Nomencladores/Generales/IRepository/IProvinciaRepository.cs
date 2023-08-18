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
    public interface IProvinciaRepository
    {
        List<Provincia> FindAllProvincias(ProvinciaSearchOptions options);
        StatusResponse InsertProvincia(Provincia user);
        StatusResponse UpdateProvincia(Provincia user);
        StatusResponse DeleteProvincia(Provincia user);
        Provincia GetProvinciabyId(int userId);
    }
}
